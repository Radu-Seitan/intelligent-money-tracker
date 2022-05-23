import {Component} from '@angular/core';
import {FormBuilder, FormControl, Validators} from "@angular/forms";
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
      email: new FormControl('', [Validators.email, Validators.required]),
      password: new FormControl('', [Validators.required, Validators.minLength(6)]),
    }),
    userData: this._formBuilder.group({
      username: new FormControl('', [Validators.required]),
      sum: [0],
    })
  })
  showPassword: boolean = true;

  constructor(
    private _formBuilder: FormBuilder,
    private _authService: AuthService,
  ) {
  }

  submitSignUpForm() {
    const authData: AuthData = this.signUpForm.get('authData')?.value;
    const userData: User = this.signUpForm.get('userData')?.value;
    this._authService.signUp(authData, userData);
  }

  get email() {
    return this.signUpForm.controls['authData'].get('email');
  }

  get password() {
    return this.signUpForm.controls['authData'].get('password');
  }

  get username() {
    return this.signUpForm.controls['userData'].get('username');
  }

}
