import {Component, OnInit} from '@angular/core';
import {ExpenseService} from "../../../services/expense.service";
import {map, Observable} from "rxjs";
import {Expense} from "../../../models/expense.model";
import {ChartData} from 'chart.js'
import {AuthService} from "../../auth/services/auth.service";
import {ChartService} from "../../../services/chart.service";
import {CategoryService} from "../../../services/category.service";
import {Income} from "../../../models/income.model";
import {IncomeService} from "../../../services/income.service";

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  expenses$ = new Observable<Expense[]>()
  incomes$ = new Observable<Income[]>()

  expenseChart$ = new Observable<ChartData<'pie', number[], string | string[]>>()
  incomeChart$ = new Observable<ChartData<'pie', number[], string | string[]>>()

  monthExpense = new Date(Date.now()).getMonth();
  monthIncome = new Date(Date.now()).getMonth();

  constructor(
    private _expenseService: ExpenseService,
    private _incomeService: IncomeService,
    readonly _authService: AuthService,
    private _chartService: ChartService,
    readonly _categoryService: CategoryService
  ) {
  }

  ngOnInit(): void {
    this.getExpensesChartData();
    this.getIncomesChartData();
    this.getExpenses();
    this.getIncomes();
  }

  getExpenses() {
    this.expenses$ = this._expenseService.getExpensesByUserId(this._authService.currentUserId).pipe(
      map(expenses => expenses.sort((a, b) => new Date(b.created!) >= new Date(a.created!) ? 1 : -1)),
      map(expenses => expenses.map(expense => {
        const e: Expense = expense;
        e.category = this._categoryService.mapExpenseCategory(e.category.toString());
        e.created = new Date(e.created!).toLocaleString('en-US', {dateStyle: 'short'});
        return e;
      }))
    );
  }

  getIncomes() {
    this.incomes$ = this._incomeService.getIncomesByUserId(this._authService.currentUserId).pipe(
      map(incomes => incomes.sort((a, b) => new Date(b.created!) >= new Date(a.created!) ? 1 : -1)),
      map(incomes => incomes.map(incomes => {
        const i: Income = incomes;
        i.category = this._categoryService.mapIncomeCategory(i.category.toString());
        i.created = new Date(i.created!).toLocaleString('en-US', {dateStyle: 'short'});
        return i;
      }))
    );
  }

  getExpensesChartData() {
    this.expenseChart$ = this._chartService.getExpensesPieChart(this._authService.currentUserId, this.monthExpense);
  }

  getIncomesChartData() {
    this.incomeChart$ = this._chartService.getIncomesPieChart(this._authService.currentUserId, this.monthIncome);
  }

  decExpenseMonth() {
    this.monthExpense--;
    this.expenseChart$ = this._chartService.getExpensesPieChart(this._authService.currentUserId, this.monthExpense);
  }

  incExpenseMonth() {
    this.monthExpense++;
    this.expenseChart$ = this._chartService.getExpensesPieChart(this._authService.currentUserId, this.monthExpense);
  }

  decIncomeMonth() {
    this.monthIncome--;
    this.incomeChart$ = this._chartService.getIncomesPieChart(this._authService.currentUserId, this.monthIncome);
  }

  incIncomeMonth() {
    this.monthIncome++;
    this.incomeChart$ = this._chartService.getIncomesPieChart(this._authService.currentUserId, this.monthIncome);
  }

  parseMonth(month: number) {
    const date = new Date();
    date.setMonth(month);
    return date.toLocaleString('default', {month: 'long'});
  }
}
