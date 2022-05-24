import {Component, OnInit} from '@angular/core';
import {StoreService} from "../../../services/store.service";
import {map, mergeAll, mergeMap, Observable, toArray} from "rxjs";
import {Store} from "../../../models/store.model";
import {Expense} from "../../../models/expense.model";
import {ExpenseService} from "../../../services/expense.service";
import {MatDialog} from "@angular/material/dialog";
import {ChartComponent} from "../components/chart/chart.component";

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.scss']
})
export class ReportsComponent implements OnInit {
  stores$ = new Observable<Store[]>()

  constructor(
    private _storeService: StoreService,
    private _expenseService: ExpenseService,
    private _matDialog: MatDialog,
  ) {
  }

  ngOnInit(): void {
    this.getStores()
  }

  getStores() {
    this.stores$ = this._storeService.getStores().pipe(
      mergeAll(),
      mergeMap(store => {
        return this._expenseService.getExpensesByStoreId(store.id!).pipe(
          map<Expense[], Store>(expense => {
            store.sum = expense.reduce((a, b) => a + b.quantity, 0);
            return store;
          })
        )
      }), toArray()
    )
  }

  getChart(store: Store) {
    this._matDialog.open(ChartComponent, {data: store});
  }
}
