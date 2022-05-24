import {Injectable} from '@angular/core';
import {AuthData} from "../models/auth-data.model";
import {User} from "../../../models/user.model";
import {UserService} from "../../../services/user.service";
import {Auth, authState, createUserWithEmailAndPassword, signInWithEmailAndPassword} from "@angular/fire/auth";
import {MatSnackBar} from "@angular/material/snack-bar";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  currentUser?: User | null = undefined;

  constructor(
    private _fireAuth: Auth,
    private _userService: UserService,
    private _snackBar: MatSnackBar,
  ) {
    this.userSetup();
  }

  get isLoggedIn() {
    return (localStorage.getItem('user') !== null && JSON.parse(localStorage.getItem('user')!) !== '{}')
      && this.currentUser !== null;
  }

  get currentUserId() {
    return JSON.parse(<string>localStorage.getItem('user')).uid;
  }

  loginWithEmail({email, password}: AuthData) {
    return signInWithEmailAndPassword(this._fireAuth, email, password).then(() => {
      this.userSetup();
      this._snackBar.open('Success!', undefined, {duration: 3000})
    }).catch((error: any) => this._snackBar.open(`Error! : ${error}`, undefined, {duration: 3000}));
  }

  signUp(authData: AuthData, user: User) {
    createUserWithEmailAndPassword(this._fireAuth, authData.email, authData.password).then((res: any) => {
      user.id = res.user?.uid;
      user.expenses = [];
      user.incomes = [];
      this._userService.createUser(user).subscribe();
      this._snackBar.open('Success!', undefined, {duration: 3000})
    }).catch((error: any) => this._snackBar.open(`Error! : ${error}`, undefined, {duration: 3000}));
  }

  signOut() {
    return this._fireAuth.signOut().then(() => {
      localStorage.setItem('user', '{}');
      this.currentUser = null;
      this._snackBar.open('Success!', undefined, {duration: 3000})
    }).catch((error: any) => this._snackBar.open(`Error! : ${error}`, undefined, {duration: 3000}))
  }

  private userSetup() {
    authState(this._fireAuth).subscribe((user: any) => {
      if (user) {
        localStorage.setItem('user', JSON.stringify(user));
        JSON.parse(localStorage.getItem('user')!);
        this._userService.getUserById(user.uid).subscribe((data: User) => this.currentUser = data);
      } else {
        localStorage.setItem('user', '{}');
        JSON.parse(localStorage.getItem('user')!);
        this.currentUser = null;
      }
    })
  }
}
