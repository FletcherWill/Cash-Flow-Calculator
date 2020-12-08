import { Component, OnInit } from '@angular/core';
import { Loan } from '../loan';
import { loans } from '../loans';

@Component({
  selector: 'app-loans',
  templateUrl: './loans.component.html',
  styleUrls: ['./loans.component.css']
})
export class LoansComponent implements OnInit {

  loans = loans;
  testLoan: Loan = {
    id: 1,
    balance: 200,
    term: 3,
    rate: 4
  };

  constructor() { }

  ngOnInit() {
  }

}
