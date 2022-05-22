import {Component, OnInit} from '@angular/core';
import {FormBuilder} from "@angular/forms";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm = this._formBuilder.group({
    email: '',
    password: '',
  });
  showPassword: boolean = true;

  constructor(private _formBuilder: FormBuilder) {
  }

  ngOnInit(): void {
  }

  submitLoginForm() {

  }
}
