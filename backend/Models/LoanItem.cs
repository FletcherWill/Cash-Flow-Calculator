public class LoanItem {
    //input parameters:
    public long Id { get; set; }
    public long Balance { get; set; }
    public long Term { get; set; }
    public long Rate { get; set; }

    //calculated parameters:
    public long MonthlyPayment { get; set; } //When this is assigned wherever, call the Monthly payment function from LoanMath.cs

}