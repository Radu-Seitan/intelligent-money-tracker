import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {RegisterComponent} from "./pages/register/register.component";
import {LoginComponent} from "./pages/login/login.component";

const routes: Routes = [
  {path: '', redirectTo: '/auth/login', pathMatch: 'full'},
  {path: 'register', component: RegisterComponent},
  {path: 'login', component: LoginComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
