import {Expense} from "./expense.model";
import {Income} from "./income.model";
import {Base} from "./base.model";

export interface User {
  id?: string
  username: string,
  sum: number,
  expenses?: Array<Expense>
  incomes?: Array<Income>
}
