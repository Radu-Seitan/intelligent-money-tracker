import {Expense} from "./Expense.model";
import {Income} from "./Income.model";

export interface User {
  id: string,
  username: string,
  sum: number,
  expenses: Array<Expense>
  incomes: Array<Income>
}
