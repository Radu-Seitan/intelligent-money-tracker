import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  expenseCategories = [
    'Bills',
    'Shopping',
    'Vacation',
    'Entertainment',
    'Stocks',
    'CryptoCurrency',
  ]

  incomeCategories = [
    'Salary',
    'Stocks',
    'Sales',
    'CryptoCurrency',
    'Gambling',
  ]

  constructor() {
  }

  mapExpenseCategory(category: string) {
    const indexCategory = parseInt(category);
    return indexCategory < this.expenseCategories.length ? this.expenseCategories[indexCategory] : 'Unknown';
  }

  mapIncomeCategory(category: string) {
    const indexCategory = parseInt(category);
    return indexCategory < this.incomeCategories.length ? this.incomeCategories[indexCategory] : 'Unknown';
  }
}
