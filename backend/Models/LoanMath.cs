using System;
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
             double monthlyPayment = loan.monthlyPayment;
             double interest = interestPayment(loan);

             double principal = monthlyPayment - interest;
             return principal;
         }

         public LoanItem updateLoan(LoanItem loan){
             loan.Balance = loan.Balance - loan.monthlyPayment;
             return loan;
         }
    }
}