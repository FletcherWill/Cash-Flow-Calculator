import { Component, OnInit } from '@angular/core';

import { LoanService } from '../loan.service';
import { Loan } from '../loan';


@Component({
  selector: 'app-cashflow',
  templateUrl: './cashflow.component.html',
  styleUrls: ['./cashflow.component.css']
})
export class CashflowComponent implements OnInit {



  constructor(private loanService: LoanService) { }

  ngOnInit(): void {
  }


  getLoanChart(loan: Loan): void {
    this.loanService.getLoanChart(loan)
        .subscribe();
  }

}
