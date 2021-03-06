import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {AuthRoutingModule} from './auth-routing.module';
import {RegisterComponent} from './pages/register/register.component';
import {ReactiveFormsModule} from "@angular/forms";
import {getAuth, provideAuth} from "@angular/fire/auth";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {MatButtonModule} from "@angular/material/button";
import {MatStepperModule} from "@angular/material/stepper";
import {MatCardModule} from "@angular/material/card";
import {AuthService} from "./services/auth.service";
import {MatIconModule} from "@angular/material/icon";
import {LoginComponent} from "./pages/login/login.component";


@NgModule({
  declarations: [
    RegisterComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    provideAuth(() => getAuth()),
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatStepperModule,
    MatCardModule,
    MatIconModule,
  ],
  providers: [AuthService]
})
export class AuthModule {
}
