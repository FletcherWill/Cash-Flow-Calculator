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

  private appURL: string;  // URL to app
  private loansURL: string;  // URL to web api
  private flowURL: string;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient, private messageService: MessageService) {
    this.appURL = 'https://localhost:5001/';
    this.loansURL = 'api/LoanItems';
    this.flowURL = 'flow';
  }

  /*
  // NEED TO CHANGE, NOT CORRECT!
  getLoans(): Observable<Loan[]> {
    this.messageService.add("All loans retrieved!");
    return of(loans);
  }
  */

  getLoans(): Observable<Loan[]> {
    return this.http.get<Loan[]>(this.appURL + this.loansURL).pipe(
      tap(_ => this.log('fetched all loans')),
      catchError(this.handleError<Loan[]>('getLoans', []))
    );
  }

  getLoan(id: number): Observable<Loan> {
    const url = `${this.loansURL}/${id}`;
    return this.http.get<Loan>(url).pipe(
      tap(_ => this.log(`fetched loan id=${id}`)),
      catchError(this.handleError<Loan>(`getLoan id=${id}`))
    );
  }

  addLoan(loan: Loan): Observable<Loan> {
    return this.http.post<Loan>(this.loansURL, loan).pipe(
      tap((newLoan: Loan) => this.log(`added loan w/ id=${newLoan.id}`)),
      catchError(this.handleError<Loan>('addLoan'))
    );
  }

  updateLoan(loan: Loan): Observable<Loan> {
    //console.log(JSON.stringify(loan));
    const id = typeof loan === 'number' ? loan : loan.id;
    const url = `${this.loansURL}/${id}`;
    
    return this.http.put<Loan>(url, JSON.stringify(loan), this.httpOptions).pipe(
      tap(_ => this.log(`updated loan id=${loan.id}`)),
      catchError(this.handleError<any>('updateLoan'))
    );
  }

  deleteLoan(loan: Loan | number): Observable<Loan> {
    const id = typeof loan === 'number' ? loan : loan.id;
    const url = `${this.loansURL}/${id}`;

    return this.http.delete<Loan>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted loan id=${id}`)),
      catchError(this.handleError<Loan>('deleteLoan'))
    );
  }

  //Doesn't have all the implementation yet. not really sure how to implement.
  getLoanChart(loan : Loan): Observable<Loan> {
    const id = typeof loan === 'number' ? loan : loan.id;
    const url = `${this.loansURL}/${this.flowURL}/${id}`;
    return this.http.get<Loan>(url).pipe(
      tap(_ => this.log(`fetched loan chart id=${id}`)),
      catchError(this.handleError<Loan>(`getLoan chart id=${id}`))
    );
  }

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

  /** Log a message with the MessageService */
  private log(message: string) {
    this.messageService.add(`${message}`);
  }

}