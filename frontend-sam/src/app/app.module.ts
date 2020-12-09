import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoansComponent } from './loans/loans.component';
import { LoanDetailComponent } from './loan-detail/loan-detail.component';
import { FormsModule } from '@angular/forms'; // <-- NgModel lives here


@NgModule({
  declarations: [
    AppComponent,
    LoansComponent,
    LoanDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
