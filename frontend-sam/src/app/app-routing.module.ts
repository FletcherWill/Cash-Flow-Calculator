import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component'; 
import { LoanDetailComponent } from './loan-detail/loan-detail.component';
import { LoansComponent } from './loans/loans.component';

const routes: Routes = [
  { path: '', component: AppComponent, pathMatch: 'full' },
  { path: 'LoanItems', component: LoansComponent, pathMatch: 'full' },
  { path: 'LoanItems/:id', component: LoanDetailComponent, pathMatch: 'full' }
];


@NgModule({
  imports: 
    [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
