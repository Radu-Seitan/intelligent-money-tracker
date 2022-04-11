import {Expense} from "./Expense.model";

export interface User {
  id: string,
  username: string,
  sum: number,
  expenses: Array<Expense>
}
