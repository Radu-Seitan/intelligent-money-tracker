import {Base} from "./Base.model";
import {User} from "./User.model";

export interface Expense extends Base{
  quantity: number,
  category: ExpenseCategory,
  userId: string,
  user?: User,
}

export enum ExpenseCategory {
  Bills,
  Shopping,
  Vacation,
  Entertainment,
  Stocks,
  CryptoCurrency
}
