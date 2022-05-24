import {Base} from "./base.model";

export interface Income extends Base {
  quantity: number,
  category: IncomeCategory | string,
  userId: string,
}

export enum IncomeCategory {
   Salary,
   Stocks,
   Sales,
   CryptoCurrency,
   Gambling
}
