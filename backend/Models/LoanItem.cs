
using System;
public class LoanItem {
    //input parameters:
    public long Id { get; set; }
    public double Balance { get; set; }
    public double Term { get; set; }
    public double Rate { get; set; }

    //calculated parameters:
    public double MonthlyPayment{ get; set; }
     //When this is assigned wherever, call the Monthly payment function from LoanMath.cs
    
}