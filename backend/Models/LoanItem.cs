public class LoanItem {
    //input parameters:
    public int Id { get; set; }
    public double Balance { get; set; }
    public int Term { get; set; }
    public double Rate { get; set; }

    //calculated parameters:
    public double monthlyPayment { get; set; } //When this is assigned wherever, call the Monthly payment function from LoanMath.cs

}