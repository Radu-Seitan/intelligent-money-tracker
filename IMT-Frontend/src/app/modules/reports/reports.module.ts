import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {ReportsRoutingModule} from './reports-routing.module';
import {ReportsComponent} from './reports/reports.component';
import {MatCardModule} from "@angular/material/card";
import {ImageComponent} from "./utils/file/image/image.component";
import {ChartComponent} from './components/chart/chart.component';
import {NgChartsModule} from "ng2-charts";
import {MatDialogModule} from "@angular/material/dialog";
import {MatIconModule} from "@angular/material/icon";


@NgModule({
  declarations: [
    ReportsComponent,
    ImageComponent,
    ChartComponent
  ],
  imports: [
    CommonModule,
    ReportsRoutingModule,
    MatCardModule,
    NgChartsModule,
    MatDialogModule,
    MatIconModule,
  ]
})
export class ReportsModule {
}
