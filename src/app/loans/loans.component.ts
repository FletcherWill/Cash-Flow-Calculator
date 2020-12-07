import { Component, OnInit } from '@angular/core';
import { Loan } from '../loan';

@Component({
  selector: 'app-loans',
  templateUrl: './loans.component.html',
  styleUrls: ['./loans.component.css']
})
export class LoansComponent implements OnInit {

  testLoan: Loan = {
    id: 1,
    balance: 2,
    term: 3,
    rate: 4
  };

  constructor() { }

  ngOnInit(): void {
  }

}
