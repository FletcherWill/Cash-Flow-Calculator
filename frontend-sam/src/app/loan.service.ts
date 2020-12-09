import { Injectable } from '@angular/core';
import { Loan } from './loan';
import { loans } from './mock-loans';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class LoanService {

  //constructor(private http: HttpClient) { }

  getLoans(): Observable<Loan[]> {
    return of(loans);
  }

  // addLoan():
  // deleteLoan(id):
  // updateLoan(id):


}
