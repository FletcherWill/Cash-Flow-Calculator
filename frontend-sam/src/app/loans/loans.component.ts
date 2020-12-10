import { ThisReceiver } from '@angular/compiler';
import { Variable } from '@angular/compiler/src/render3/r3_ast';
import { Component, OnInit } from '@angular/core';
import { Loan } from '../loan';
import { LoanService } from '../loan.service';
import { MessageService } from '../message.service';

@Component({
  selector: 'app-loans',
  templateUrl: './loans.component.html',
  styleUrls: ['./loans.component.css']
})
export class LoansComponent implements OnInit {

  // ?
  loans: Loan[] = [];
  selectedLoan!: Loan;
  loanCount : number = 0;

  constructor(private loanService: LoanService, private messageService: MessageService) { }

  getLoans(): void {
    this.loanService.getLoans()
        .subscribe(loans => this.loans = loans);
  }

  onSelect(loan: Loan): void {
    this.selectedLoan = loan;
  }

  add(balance: String, term: String, rate: String): void {
    this.loanCount++;
    if (!balance||!term||!rate) { return; }
    var newBalance: number = +balance;
    var newTerm: number = +term;
    var newRate: number = +rate;
    var loan = { 
      id: this.loanCount,
      balance: newBalance,
      term: newTerm,
      rate: newRate }
    this.loanService.addLoan(loan)
      .subscribe(loan => {
        this.loans.push(loan);
      });
  }

  deleteLoan(loan: Loan): void {
    this.loanService.deleteLoan(loan)
      .subscribe(loans => this.selectedLoan = loans);
  }
  
  updateLoan(loan: Loan): void {
    var newBalance: number = +loan.balance;
    var newTerm: number = +loan.term;
    var newRate: number = +loan.rate;
    loan = { 
      id: loan.id,
      balance: newBalance,
      term: newTerm,
      rate: newRate}
    this.loanService.updateLoan(loan)
      .subscribe(loan => this.selectedLoan = loan);
  }
  


  // this should update the selected loan
/*
  save(): void {
    this.loanService.updateLoan(this.loan)
      .subscribe(() => this.goBack());
  }
  */


  ngOnInit() {
    this.getLoans();
  }

}
