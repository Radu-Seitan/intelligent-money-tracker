import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {DashboardRoutingModule} from './dashboard-routing.module';
import {DashboardComponent} from "./dashboard/dashboard.component";
import {NgChartsModule} from "ng2-charts";
import {MatCardModule} from "@angular/material/card";
import {MatButtonModule} from "@angular/material/button";
import {MatIconModule} from "@angular/material/icon";
import {MatTabsModule} from "@angular/material/tabs";
import {ScrollingModule} from "@angular/cdk/scrolling";


@NgModule({
  declarations: [
    DashboardComponent,
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    NgChartsModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatTabsModule,
    ScrollingModule,
  ]
})
export class DashboardModule {
}
