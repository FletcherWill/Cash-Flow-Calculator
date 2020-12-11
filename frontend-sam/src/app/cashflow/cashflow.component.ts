import { Component, OnInit } from '@angular/core';

import { LoanService } from '../loan.service';
import { Loan } from '../loan';


@Component({
  selector: 'app-cashflow',
  templateUrl: './cashflow.component.html',
  styleUrls: ['./cashflow.component.css']
})
export class CashflowComponent implements OnInit {

  cashflows: cashflowChart[] = [];
  loans: Loan[] = [];

  constructor(private loanService: LoanService) { }

  ngOnInit(): void {
  }

  getCashflows(): void {
    this.loanService.getLoans()
        .subscribe(loans => this.loans = loans);

    for (const loan of this.loans)
    {
      this.cashflows.push(this.getLoanChart(loan))
    }
  }

  getLoanChart(loan: Loan): void {
    this.loanService.getLoanChart(loan)
        .subscribe();
  }

}
