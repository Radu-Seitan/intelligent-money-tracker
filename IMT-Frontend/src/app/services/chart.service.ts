import {Injectable} from '@angular/core';
import {ExpenseService} from "./expense.service";
import {map} from "rxjs";
import {Expense} from "../models/expense.model";
import {ChartData} from "chart.js";
import * as _ from "lodash";
import {CategoryService} from "./category.service";
import {IncomeService} from "./income.service";
import {Income} from "../models/income.model";

@Injectable({
  providedIn: 'root'
})
export class ChartService {

  constructor(
    private _expenseService: ExpenseService,
    private _categoryService: CategoryService,
    private _incomeService: IncomeService,
  ) {
  }

  getExpensesPieChart(userId: string, month: number) {
    return this._expenseService.getExpensesByUserId(userId).pipe(
      map<Expense[], ChartData<'pie', number[], string | string[]>>((expenses: Expense[]) => {
        const data = expenses.filter(d => new Date(d.created!).getMonth() === month)
        const labels: string[] = []
        const sets = []
        let categories = _.groupBy(data, 'category');
        for (const category of Object.keys(categories)) {
          const quantity = categories[category].reduce((a, b) => a + b.quantity, 0)
          sets.push(quantity)
          labels.push(this._categoryService.mapExpenseCategory(category));
        }
        const datasets = [{
          data: sets
        }]
        return {datasets: datasets, labels: labels} as ChartData<'pie', number[], string | string[]>
      }))
  }

  getIncomesPieChart(userId: string, month: number) {
    return this._incomeService.getIncomesByUserId(userId).pipe(
      map<Income[], ChartData<'pie', number[], string | string[]>>((incomes: Income[]) => {
        const data = incomes.filter(d => new Date(d.created!).getMonth() === month)
        const labels: string[] = []
        const sets = []
        let categories = _.groupBy(data, 'category');
        for (const category of Object.keys(categories)) {
          const quantity = categories[category].reduce((a, b) => a + b.quantity, 0)
          sets.push(quantity)
          labels.push(this._categoryService.mapIncomeCategory(category));
        }
        const datasets = [{
          data: sets
        }]
        return {datasets: datasets, labels: labels} as ChartData<'pie', number[], string | string[]>
      }))
  }
}
