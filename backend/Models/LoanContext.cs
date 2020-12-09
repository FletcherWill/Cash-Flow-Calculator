using Microsoft.EntityFrameworkCore;
namespace LoanApi.Models
{
    public class LoanContext : DbContext {
        public LoanContext(DbContextOptions<LoanContext> options)
            : base (options)
        { }

        //If I'm thinking right, the Dbset is a list of all the loans we currently have. So we can track the pool of loans with it.
        public DbSet<LoanItem> LoanItems { get; set; }

        //Depending wether or not my assumption is right, this may or may not function righht.
        public double Balance {
            get { return Balance; }
            set { 
                Balance = 0;
                foreach (LoanItem loan in LoanItems){
                Balance = Balance + loan.Balance;
            }}
        }
    }
}