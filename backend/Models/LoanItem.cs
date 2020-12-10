using System;
using System.Collections.Generic;
public class LoanItem {
    //input parameters:
    public long Id { get; set; }
    public long Balance { get; set; }
    public long Term { get; set; }
    public long Rate { get; set; }
    public long MonthlyPayment { get; set; } //When this is assigned wherever, call the Monthly payment function from LoanMath.cs

    public long monthlyPayment(){ //Only called once per loan
        double payment = Balance * (Rate/1200) / Math.Pow((1 - (1 + Rate/1200)), (-1 * Term)); //Formula from assignment instructions.
        return (long)payment;
    }

    public long interestPayment(){
        long interest = Balance * (Rate / 1200);
        return interest;
    }

    public long principalPayment(){
        long interest = interestPayment();
        if (MonthlyPayment == 0)
            MonthlyPayment = monthlyPayment();
        long principal = MonthlyPayment - interest;
        return principal;
    }

    public LoanItem updateLoan(){
        if (MonthlyPayment == 0)
            MonthlyPayment = monthlyPayment();
        Balance = Balance - MonthlyPayment;
        return this;
    }

    public List<List<double>> getLoanPaymentChart(){
        if (MonthlyPayment == 0)
            MonthlyPayment = monthlyPayment();
        long BeginningBalance = Balance;
        List<List<double>> loanPaymentChart = new List<List<double>>();
        int month = 1;
        while (Balance > 0) {
         	List<double> insert = new List<double>();
         	insert.Add(month);
         	insert.Add(interestPayment());
         	insert.Add(principalPayment());
         	updateLoan();
         	month = month + 1;
            insert.Add(Balance);
            loanPaymentChart.Add(insert);
        }
        Balance = BeginningBalance;
        return loanPaymentChart;
    }
}