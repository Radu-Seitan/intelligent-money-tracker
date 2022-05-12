import {Injectable} from '@angular/core';
import {AngularFireAuth} from "@angular/fire/compat/auth";
import {AuthData} from "../models/auth-data.model";
import {GoogleAuthProvider} from 'firebase/auth'
import {User} from "../../../models/user.model";
import {UserService} from "../../../services/user.service";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private _fireAuth: AngularFireAuth,
    private _userService: UserService,
  ) {
  }

  loginWithEmail({email, password}: AuthData) {
    return this._fireAuth.signInWithEmailAndPassword(email, password).then().catch(error => console.error(error));
  }

  loginWithGoogle() {
    return this._fireAuth.signInWithPopup(new GoogleAuthProvider()).then().catch(error => console.error(error));
  }

  signUp(authData: AuthData, user: User) {
    this._fireAuth.createUserWithEmailAndPassword(authData.email, authData.password).then().catch(error => console.error(error));
  }
}
