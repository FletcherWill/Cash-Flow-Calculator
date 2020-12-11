using System;
using System.Collections.Generic;
public class LoanItem {
    //input parameters:
    public long Id { get; set; }
    public float Balance { get; set; }
    public long Term { get; set; }
    public float Rate { get; set; }
    public float MonthlyPayment { get; set; } //When this is assigned wherever, call the Monthly payment function from LoanMath.cs

    public float monthlyPayment(float remainingBalance){
        float part1 = (float)(remainingBalance * (Rate / 1200.0));
        //Console.WriteLine(part1);
        float part2 = (float)Math.Pow(1 + (Rate / 1200.0), (-1.0 * Term)); 
        //Console.WriteLine(part2);
        float part3 = (float)(part1 / (1.0 - part2));
        //Console.WriteLine(part3);

        //double payment = Balance * (Rate/1200) / (1 - Math.Pow( (1 + Rate/1200), (-1 * Term))); //Formula from assignment instructions.
        //Console.WriteLine(Balance + " * ( " + Rate + " / 1200) / Math.Pow(( 1 - ( 1 + " + Rate + " / 1200)), ( -1 * " + Term + "));");
        //Console.WriteLine(part3);
        return part3;
    }

    public float interestPayment(){
        float interest = (float)(Balance * (Rate / 1200.0));
        //Console.WriteLine(interest);
        return interest;
    }

    public float principalPayment(float remainingBalance){
        float interest = interestPayment();
        if (this.MonthlyPayment == 0)
            this.MonthlyPayment = monthlyPayment(remainingBalance);
        float principal = (float)(this.MonthlyPayment - interest);
        //Console.WriteLine(principal);
        return principal;
    }

    public List<List<float>> getLoanPaymentChart(){
        float BeginningBalance = Balance;
        List<List<float>> loanPaymentChart = new List<List<float>>();
        int month = 1;

        while (Balance > 0 & month <= this.Term ) {
            //Console.WriteLine("Balance: " + this.Balance + " Term: " + this.Term + " Montly Payment: " + this.MonthlyPayment);
         	List<float> insert = new List<float>();
         	insert.Add(month);
         	insert.Add(interestPayment());
         	insert.Add(principalPayment(Balance));
         	month = month + 1;
            if (MonthlyPayment == 0)
                MonthlyPayment = monthlyPayment(Balance);
            Balance = Balance - MonthlyPayment;
            insert.Add(Balance);
            loanPaymentChart.Add(insert);
        }
        Balance = BeginningBalance;
        return loanPaymentChart;
    }
}