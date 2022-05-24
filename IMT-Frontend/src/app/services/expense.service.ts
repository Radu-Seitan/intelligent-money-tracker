import {Injectable} from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Expense, ExpenseCategory} from "../models/expense.model";

@Injectable({
  providedIn: 'root'
})
export class ExpenseService {
  readonly #baseUrl = environment.apiUrl;
  readonly #endpoint = '/api/Expenses';

  constructor(private _http: HttpClient) {
  }

  getExpenses() {
    return this._http.get<Expense[]>(`${this.#baseUrl}${this.#endpoint}/all`);
  }

  getExpensesByCategory(category: ExpenseCategory) {
    return this._http.get<Expense[]>(`${this.#baseUrl}${this.#endpoint}/all/${category}`);
  }

  getExpensesByUserId(userId: string) {
    return this._http.get<Expense[]>(`${this.#baseUrl}${this.#endpoint}/${userId}`);
  }

  getExpensesByUserIdAndCategory(userId: string, category: ExpenseCategory) {
    return this._http.get<Expense[]>(`${this.#baseUrl}${this.#endpoint}/${userId}/${category}`);
  }

  getExpensesByStoreId(storeId: number) {
    return this._http.get<Expense[]>(`${this.#baseUrl}${this.#endpoint}/stores/${storeId}`);
  }

  getExpensesByStoreIdAndCategory(storeId: number, category: ExpenseCategory) {
    return this._http.get<Expense[]>(`${this.#baseUrl}${this.#endpoint}/stores/${storeId}/${category}`);
  }
}
