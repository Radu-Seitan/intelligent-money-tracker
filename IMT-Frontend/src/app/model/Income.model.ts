import {Base} from "./Base.model";
import {User} from "./User.model";

export interface Income extends Base {
  quantity: number,
  category: IncomeCategory,
  userId: string,
  user: User
}

export enum IncomeCategory {
   Salary,
   Stocks,
   Sales,
   CryptoCurrency,
   Gambling
}
