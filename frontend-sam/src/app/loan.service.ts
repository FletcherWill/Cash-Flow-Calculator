import { Injectable } from '@angular/core';
import { Loan } from './loan';
import { loans } from './mock-loans';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root'
})

export class LoanService {

  private loansUrl = 'api/heroes';  // URL to web api

  constructor(private http: HttpClient, private messageService: MessageService) { }

  
  getLoans(): Observable<Loan[]> {
    this.messageService.add("LoanService: fetched all loans");
    return of(loans);
  }
  
  
  /*
  getLoans(): Observable<Loan[]> {
    this.messageService.add("LoanService: fetched all loans");
    return this.http.get<Loan[]>(this.loansUrl)
  }
  */

  
  // getLoan(id):
  // addLoan():
  // deleteLoan(id):
  // updateLoan(id):


}
