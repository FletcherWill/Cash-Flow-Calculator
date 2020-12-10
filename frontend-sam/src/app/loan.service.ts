import { Injectable } from '@angular/core';
import { Loan } from './loan';
import { loans } from './mock-loans';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MessageService } from './message.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class LoanService {

  appURL: string;  // URL to app
  loansURL: string;  // URL to web api

  constructor(private http: HttpClient, private messageService: MessageService) { 
    this.appURL = environment.appURL;
    this.loansURL = 'api/heroes';
  }

  // NEED TO CHANGE, NOT CORRECT!
  getLoans(): Observable<Loan[]> {
    this.messageService.add("Retrieved all loans");
    return of(loans);
  }
  
  // an attempt at writing methods that get data from backend
  /*

  getLoans(): Observable<Loan[]> {
    this.messageService.add("All loans retrieved!");
    return this.http.get<Loan[]>(this.appURL + this.loansURL)

  getLoan(id: number): Observable<Loan> {
      this.messageService.add("Retrieved a loan!");
      return this.http.get<Loan>(this.appURL + this.loansURL + id);
  }

  saveLoan(Loan): Observable<Loan> {
      this.messageService.add("Loan saved!");
      return this.http.post<Loan>(this.appURL + this.loansURL, JSON.stringify(Loan), this.httpOptions);
  }

  updateLoan(id: number, Loan): Observable<Loan> {
      this.messageService.add("Loan updated!");
      return this.http.put<Loan>(this.appURL + this.loansURL + id, JSON.stringify(Loan), this.httpOptions);
  }

  deleteLoan(id: number): Observable<Loan> {
      this.messageService.add("Loan deleted!");
      return this.http.delete<Loan>(this.appURL + this.loansURL + id);
  }

  */

}
