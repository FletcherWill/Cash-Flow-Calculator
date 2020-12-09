import { Component, OnInit } from '@angular/core';
import { Loan } from '../loan';
import { LoanService } from '../loan.service';

@Component({
  selector: 'app-loans',
  templateUrl: './loans.component.html',
  styleUrls: ['./loans.component.css']
})
export class LoansComponent implements OnInit {

  // ?
  loans: Loan[] = [];

  constructor(private loanService: LoanService) { }

  getLoans(): void {
    this.loanService.getLoans()
        .subscribe(loans => this.loans = loans);
  }

  ngOnInit() {
    this.getLoans();
  }

}
