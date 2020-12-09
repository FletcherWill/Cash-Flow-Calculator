import { Injectable } from '@angular/core';
import { Loan } from './loan';
import { loans } from './mock-loans';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class LoanService {

  constructor() { }

  getLoans(): Observable<Loan[]> {
    return of(loans);
  }

  
}
