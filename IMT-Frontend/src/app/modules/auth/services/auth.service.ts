import {Injectable} from '@angular/core';
import {AngularFireAuth} from "@angular/fire/compat/auth";
import {AuthData} from "../models/auth-data.model";
import {User} from "../../../models/user.model";
import {UserService} from "../../../services/user.service";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  currentUser: User | null = null;

  constructor(
    private _fireAuth: AngularFireAuth,
    private _userService: UserService,
  ) {
    this.userSetup();
  }

  get isLoggedIn() {
    return (localStorage.getItem('user') !== null && JSON.parse(localStorage.getItem('user')!) !== '{}')
      && this.currentUser !== null;
  }

  loginWithEmail({email, password}: AuthData) {
    return this._fireAuth.signInWithEmailAndPassword(email, password).then(() => {
      this.userSetup();
    }).catch(error => console.error(error));
  }

  signUp(authData: AuthData, user: User) {
    this._fireAuth.createUserWithEmailAndPassword(authData.email, authData.password).then((res) => {
      user.id = res.user?.uid;
      user.expenses = [];
      user.incomes = [];
      this._userService.createUser(user).subscribe()
    }).catch(error => console.error(error));
  }

  signOut() {
    return this._fireAuth.signOut().then(() => {
      localStorage.setItem('user', '{}');
      this.currentUser = null;
    }).catch(error => console.log(error))
  }

  private userSetup() {
    this._fireAuth.authState.subscribe(user => {
      if (user) {
        localStorage.setItem('user', JSON.stringify(user));
        JSON.parse(localStorage.getItem('user')!);
        this._userService.getUserById(user.uid).subscribe(data => this.currentUser = data);
      } else {
        localStorage.setItem('user', '{}');
        JSON.parse(localStorage.getItem('user')!);
        this.currentUser = null;
      }
    })
  }
}
