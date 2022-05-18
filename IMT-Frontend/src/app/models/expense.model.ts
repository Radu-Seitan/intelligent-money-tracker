import {Base} from "./base.model";

export interface Expense extends Base {
  quantity: number,
  category: ExpenseCategory,
  userId: string,
}

export enum ExpenseCategory {
  Bills,
  Shopping,
  Vacation,
  Entertainment,
  Stocks,
  CryptoCurrency
}
