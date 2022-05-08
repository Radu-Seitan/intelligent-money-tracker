import {Base} from "./base.model";

export interface Income extends Base {
  quantity: number,
  category: IncomeCategory,
  userId: string,
}

export enum IncomeCategory {
   Salary,
   Stocks,
   Sales,
   CryptoCurrency,
   Gambling
}
