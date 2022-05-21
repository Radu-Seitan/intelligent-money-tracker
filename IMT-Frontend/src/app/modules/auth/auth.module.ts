import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {AuthRoutingModule} from './auth-routing.module';
import {LoginComponent} from './pages/login/login.component';
import {ReactiveFormsModule} from "@angular/forms";
import {getAuth, provideAuth} from "@angular/fire/auth";
import {AuthService} from "./services/auth.service";


@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    provideAuth(() => getAuth()),
    ReactiveFormsModule,
  ],
  providers: [AuthService]
})
export class AuthModule {
}
