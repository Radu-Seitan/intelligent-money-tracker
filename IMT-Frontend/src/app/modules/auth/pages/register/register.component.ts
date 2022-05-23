import {Component} from '@angular/core';
import {FormBuilder} from "@angular/forms";
import {AuthService} from "../../services/auth.service";
import {AuthData} from "../../models/auth-data.model";
import {User} from "../../../../models/user.model";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
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
  showPassword: boolean = true;

  constructor(
    private _formBuilder: FormBuilder,
    private _authService: AuthService,
  ) { }

  submitSignUpForm() {
    const authData: AuthData = this.signUpForm.get('authData')?.value;
    const userData: User = this.signUpForm.get('userData')?.value;
    this._authService.signUp(authData, userData);
  }

}
