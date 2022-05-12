import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
    NbThemeModule,
    NbLayoutModule,
    NbSidebarModule,
    NbButtonModule,
    NbMenuModule,
    NbSidebarService, NbIconModule, NbFormFieldModule, NbInputModule, NbStepperModule
} from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import {RouterModule} from "@angular/router";
import {AngularFireModule} from "@angular/fire/compat";
import {environment} from "../environments/environment";
import {HttpClientModule} from "@angular/common/http";

@NgModule({
  declarations: [
    AppComponent,
  ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        NbMenuModule.forRoot(),
        NbThemeModule.forRoot({name: 'dark'}),
        NbLayoutModule,
        NbEvaIconsModule,
        RouterModule, // RouterModule.forRoot(routes, { useHash: true }), if this is your app.module
        NbLayoutModule,
        NbSidebarModule, // NbSidebarModule.forRoot(), //if this is your app.module
        NbButtonModule,
        NbIconModule,
        NbFormFieldModule,
        NbInputModule,
        NbStepperModule,
    ],
  providers: [NbSidebarService],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AngularFireModule.initializeApp(environment.firebaseConfig),
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
