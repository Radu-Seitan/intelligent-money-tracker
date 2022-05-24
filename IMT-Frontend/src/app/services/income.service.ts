import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Income, IncomeCategory} from "../models/income.model";

@Injectable({
  providedIn: 'root'
})
export class IncomeService {
  readonly #baseUrl = environment.apiUrl;
  readonly #endpoint = '/api/Incomes';

  constructor(private _http: HttpClient) {
  }

  getIncomes() {
    return this._http.get<Income[]>(`${this.#baseUrl}${this.#endpoint}/all`);
  }

  getIncomesByCategory(category: IncomeCategory) {
    return this._http.get<Income[]>(`${this.#baseUrl}${this.#endpoint}/all/${category}`);
  }

  getIncomesByUserId(userId: string) {
    return this._http.get<Income[]>(`${this.#baseUrl}${this.#endpoint}/${userId}`);
  }

  getIncomesByUserIdAndCategory(userId: string, category: IncomeCategory) {
    return this._http.get<Income[]>(`${this.#baseUrl}${this.#endpoint}/${userId}/${category}`);
  }

}
