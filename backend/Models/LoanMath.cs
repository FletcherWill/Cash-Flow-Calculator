using System;
using System.Collections.Generic;

namespace Microsoft.Collections.Generic {
    public class LoanMath {

        //Formulas for the calculator:
        public double monthlyPayment(LoanItem loan){ //Only called once per loan
            double balance = loan.Balance;
            double rate = loan.Rate;
            int term = loan.Term;
            double payment = balance * (rate/1200) / Math.Pow((1 - (1 + rate/1200)), (-1 * term)); //Formula from assignment instructions.
            return payment;
        }

         public double interestPayment(LoanItem loan){
             double rate = loan.Rate;
             double balance = loan.Balance;

             double interest = balance * (rate / 1200);
             return interest;
         }

         public double principalPayment(LoanItem loan){
             double monthlyPayment = loan.MonthlyPayment;
             double interest = interestPayment(loan);

             double principal = monthlyPayment - interest;
             return principal;
         }

         public LoanItem updateLoan(LoanItem loan){
             loan.Balance = loan.Balance - loan.MonthlyPayment;
             return loan;
         }

         public List<List<double>> getLoanPaymentChart(LoanItem loan){
            // probably need to copy loan
            LoanItem Loan = new LoanItem(){Id = loan.Id, Balance = loan.Balance, Term = loan.Term, Rate = loan.Rate};
            Loan.MonthlyPayment = monthlyPayment(Loan);
         	List<List<double>> loanPaymentChart = new List<List<double>>();
         	int month = 1;
         	while (Loan.Balance > 0) {
         		List<double> insert = new List<double>();
         		insert.Add(month);
         		insert.Add(interestPayment(Loan));
         		insert.Add(principalPayment(Loan));
         		loan = updateLoan(Loan);
         		month = month + 1;
                insert.Add(loan.Balance);
                loanPaymentChart.Add(insert);
         	}
            return loanPaymentChart;
         }

         public List<List<double>> getCharts(List<LoanItem> loans){
             List<List<List<double>>> charts = new List<List<List<double>>>();
             List<List<double>> chart = new List<List<double>>();
             int maxRows = 0;
             foreach (var loan in loans) {
                 List<List<double>> tempChart = getLoanPaymentChart(loan);
                 charts.Add(tempChart);
                 maxRows = Math.Max(maxRows,tempChart.Count);
             }
             for (var row = 0; row < maxRows; row++) {
                 List<double> insert = new List<double> {0,0,0,0};
                 foreach (var ch in charts) {
                     if (ch.Count > row) {
                         List<double> chRow = ch[row];
                         insert[0] += chRow[0];
                         insert[1] += chRow[1];
                         insert[2] += chRow[2];
                         insert[3] += chRow[3];
                     }
                 }
                 chart.Add(insert);
             }
             return chart;
             
         }
    }
}