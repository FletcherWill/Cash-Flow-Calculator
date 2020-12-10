using System;
using System.Collections.Generic;
public class LoanItem {
    //input parameters:
    public long Id { get; set; }
    public long Balance { get; set; }
    public long Term { get; set; }
    public long Rate { get; set; }
    public double MonthlyPayment { get; set; } //When this is assigned wherever, call the Monthly payment function from LoanMath.cs

    public double monthlyPayment(){
        double part1 = Balance * (Rate/ 1200.0);
        //Console.WriteLine(part1);
        double part2 = Math.Pow(1 + (Rate / 1200.0), (-1.0 * Term)); 
        //Console.WriteLine(part2);
        double part3 = part1 / (1.0 - part2);
        //Console.WriteLine(part3);

        //double payment = Balance * (Rate/1200) / (1 - Math.Pow( (1 + Rate/1200), (-1 * Term))); //Formula from assignment instructions.
        //Console.WriteLine(Balance + " * ( " + Rate + " / 1200) / Math.Pow(( 1 - ( 1 + " + Rate + " / 1200)), ( -1 * " + Term + "));");
        //Console.WriteLine(part3);
        return part3;
    }

    public double interestPayment(){
        double interest = Balance * (Rate / 1200.0);
        Console.WriteLine(interest);
        return interest;
    }

    public double principalPayment(){
        double interest = interestPayment();
        if (this.MonthlyPayment == 0)
            this.MonthlyPayment = monthlyPayment();
        double principal = this.MonthlyPayment - interest;
        //Console.WriteLine(principal);
        return principal;
    }

    public List<List<double>> getLoanPaymentChart(){
        if (MonthlyPayment == 0)
            MonthlyPayment = monthlyPayment();
        long BeginningBalance = Balance;
        List<List<double>> loanPaymentChart = new List<List<double>>();
        int month = 1;

        while (Balance > 0 & month <= this.Term ) {
            Console.WriteLine("Balance: " + this.Balance + " Term: " + this.Term);
         	List<double> insert = new List<double>();
         	insert.Add(month);
         	insert.Add(interestPayment());
         	insert.Add(principalPayment());
         	month = month + 1;
            if (MonthlyPayment == 0)
                MonthlyPayment = monthlyPayment();
            Balance = Balance - (long)MonthlyPayment;
            insert.Add(Balance);
            loanPaymentChart.Add(insert);
        }
        Balance = BeginningBalance;
        return loanPaymentChart;
    }
}