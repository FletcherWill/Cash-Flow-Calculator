import { Loan } from './loan';

export interface LoanList {
    id: Array<{ loan: Loan }>;
  }