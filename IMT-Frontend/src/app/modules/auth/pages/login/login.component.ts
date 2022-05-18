import { Component, OnInit } from '@angular/core';
import {FormBuilder} from "@angular/forms";
import {AuthService} from "../../services/auth.service";
import {AuthData} from "../../models/auth-data.model";
import {User} from "../../../../models/user.model";
import {UserService} from "../../../../services/user.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  signUpForm = this._formBuilder.group({
    authData: this._formBuilder.group({
      email: [''],
      password: [''],
    }),
    userData: this._formBuilder.group({
      username: [''],
      sum: [0],
    })
  })

  constructor(
    private _formBuilder: FormBuilder,
    private _authService: AuthService,
    private _userService: UserService,
  ) { }

  ngOnInit(): void {
    this._userService.getUsers().subscribe(console.log);
  }

  submitSignUpForm() {
    const authData: AuthData = this.signUpForm.get('authData')?.value;
    const userData: User = this.signUpForm.get('userData')?.value;
    this._authService.signUp(authData, userData);
  }
}
