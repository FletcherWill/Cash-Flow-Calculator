import { Component, OnInit } from '@angular/core';
import { Loan } from '../loan';
<<<<<<< HEAD
import { loans } from '../loans';
=======
import { LoanService } from '../loan.service';
>>>>>>> 48bfe0223b43facbaedfbe678a36a51a36171abe

@Component({
  selector: 'app-loans',
  templateUrl: './loans.component.html',
  styleUrls: ['./loans.component.css']
})
export class LoansComponent implements OnInit {

<<<<<<< HEAD
  loans = loans;
  testLoan: Loan = {
    id: 1,
    balance: 200,
    term: 3,
    rate: 4
  };

  constructor() { }

  ngOnInit() {
=======
  // ?
  loans: Loan[] = [];

  constructor(private loanService: LoanService) { }

  getLoans(): void {
    this.loanService.getLoans()
        .subscribe(loans => this.loans = loans);
  }

  ngOnInit() {
    this.getLoans();
>>>>>>> 48bfe0223b43facbaedfbe678a36a51a36171abe
  }

}
