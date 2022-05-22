import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {environment} from "../environments/environment";
import {HttpClientModule} from "@angular/common/http";
import {initializeApp, provideFirebaseApp} from "@angular/fire/app";
import {ReactiveFormsModule} from "@angular/forms";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {NavBarComponent} from './shared/nav-bar/nav-bar.component';
import {MatToolbarModule} from "@angular/material/toolbar";
import {getAuth, provideAuth} from "@angular/fire/auth";

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    provideFirebaseApp(() => initializeApp(environment.firebaseConfig)),
    HttpClientModule,
    ReactiveFormsModule,
    MatToolbarModule,
    provideAuth(() => getAuth()),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
