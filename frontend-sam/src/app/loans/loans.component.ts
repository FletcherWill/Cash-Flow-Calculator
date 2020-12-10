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

  constructor(private loanService: LoanService, private messageService: MessageService) { }

  getLoans(): void {
    this.loanService.getLoans()
        .subscribe(loans => this.loans = loans);
  }

  onSelect(loan: Loan): void {
    this.selectedLoan = loan;
  }

  /*
  save(loan: Loan): void {
    this.loanService.updateLoan(loan)
      .subscribe(() => this.goBack());
  }
  */


  ngOnInit() {
    this.getLoans();
  }

}
