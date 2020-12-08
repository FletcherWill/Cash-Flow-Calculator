using System;
namespace Microsoft.Collections.Generic {
    public class LoanMath {

        //Formulas for the calculator:
        //monthlyPayment not used right now, currently done in loan controller with postLoan
        public static double monthlyPayment(LoanItem loan){ //Only called once per loan
            double balance = loan.Balance;
            double rate = loan.Rate;
            double term = loan.Term;
            double payment = balance * (rate/1200) / Math.Pow((1 - (1 + rate/1200)), (-1 * term)); //Formula from assignment instructions.
            return payment;
        }

         public static double interestPayment(LoanItem loan){
             double rate = loan.Rate;
             double balance = loan.Balance;

             double interest = balance * (rate / 1200);
             return interest;
         }

         public static double principalPayment(LoanItem loan){
             double monthlyPayment = loan.MonthlyPayment;
             double interest = interestPayment(loan);

             double principal = monthlyPayment - interest;
             return principal;
         }

         public static LoanItem updateLoan(LoanItem loan){
             if (loan.Balance > 0){
                 loan.Balance = loan.Balance - loan.MonthlyPayment;
             }
             return loan;
         }
    }
}