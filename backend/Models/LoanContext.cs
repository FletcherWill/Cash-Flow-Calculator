using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LoanApi.Models
{
    public class LoanContext : DbContext {
        public LoanContext(DbContextOptions<LoanContext> options)
            : base (options)
        { }

        //If I'm thinking right, the Dbset is a list of all the loans we currently have. So we can track the pool of loans with it.
        public DbSet<LoanItem> LoanItems { get; set; }

        public List<List<List<float>>> getPooledChart(){
            //Calculates the loan charts once and saves them.
            //Also need to find the largest term.
            int largestTerm = 0;
            List<List<List<float>>> loanCharts = new List<List<List<float>>>();
            foreach(LoanItem loan in LoanItems){
                    List<List<float>> loanChart = loan.getLoanPaymentChart();
                    if (loan.Term > largestTerm){
                        largestTerm = (int)loan.Term;
                    }
                    loanCharts.Add(loanChart);
            }

            //Begins pooling the loans.
            //By month
            int month = 0;
            List<List<List<float>>> pooledChart = new List<List<List<float>>>();
            while (month < largestTerm){
                //By Loan
                List<List<float>> monthChart = new List<List<float>>();
                int index = 0;
                //Keeping track of these while in the for loop. Adding to them.
                float principialPayment = 0;
                float interestPayment = 0;
                float remainingBalance = 0;
                foreach(LoanItem loan in LoanItems){
                    if (month < loan.Term) {
                        //if the loan still has time to go, it adds that month's information to the chart.
                        monthChart.Add(loanCharts[index][month]);
                        interestPayment += loanCharts[index][month][1];
                        principialPayment += loanCharts[index][month][2];
                        remainingBalance += loanCharts[index][month][3];
                    }
                    index++;
                }
                List<float> monthlyPool = new List<float>();
                monthlyPool.Add((float)(month+1));
                monthlyPool.Add(interestPayment);
                monthlyPool.Add(principialPayment);
                monthlyPool.Add(remainingBalance);
                monthChart.Add(monthlyPool);
                month++;
                pooledChart.Add(monthChart);
            }
    	    return pooledChart;
        }
    }
}