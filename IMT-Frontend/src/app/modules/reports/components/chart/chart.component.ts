import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA} from "@angular/material/dialog";
import {Store} from "../../../../models/store.model";
import {ChartService} from "../../../../services/chart.service";
import {Observable} from "rxjs";
import {ChartData} from "chart.js";

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss']
})
export class ChartComponent implements OnInit {
  chart$ = new Observable<ChartData<'pie', number[], string | string[]>>();

  constructor(
    @Inject(MAT_DIALOG_DATA) public store: Store,
    private _chartService: ChartService,
  ) {
  }

  ngOnInit(): void {
    this.getChartData();
  }

  getChartData() {
    this.chart$ = this._chartService.getExpensesPieChartStore(this.store.id!);
  }
}
