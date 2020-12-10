import { Injectable } from '@angular/core';
import { Loan } from './loan';
import { loans } from './mock-loans';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MessageService } from './message.service';
import { environment } from 'src/environments/environment';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class LoanService {

  appURL: string;  // URL to app
  loansURL: string;  // URL to web api

  constructor(private http: HttpClient, private messageService: MessageService){
    this.appURL = environment.appURL;
    this.loansURL = 'api/heroes';
  }

  /** GET heroes from the server */
  getLoans(): Observable<Loan[]> {
    return this.http.get<Loan[]>(this.loansURL)
      .pipe(
        tap(_ => this.log('fetched loans')),
        catchError(this.handleError<Loan[]>('getLoans', []))
      );
  }
/*
  addLoan(loan: Loan): Observable<Loan> {
    return this.http.post<Loan>(this.loansURL, loan, this.httpOptions).pipe(
      tap((newLoan: Loan) => this.log(`added loan w/ balance=${newLoan.balance}`)),
      catchError(this.handleError<Loan>('addLoan'))
    );
  }
 */

   /** Handle Http operation that failed */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

   /** Log a LoanService message with the MessageService */
  private log(message: string) {
    this.messageService.add(`LoanService: ${message}`);
  }
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

