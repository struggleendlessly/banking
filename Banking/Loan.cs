using System;

namespace Banking
{
    /// <summary>
    /// Represents loan. Also provides method for getting loan data.
    /// </summary>
    public class Loan
    {
        public double Amount { get; set; }

        public int DurationMonths { get; set; }

        public double AnnualInterestRate { get; set; }

        public double MaximalAdministrationFeeAmount { get; set; }

        public int AdministrationFeePercentage { get; set; }

        /// <summary>
        /// Returns Loan model with terms for the Loan.
        /// </summary>
        /// <returns>Returns model typeof <see cref="Loan"/>.</returns>
        public static Loan GetLoanData()
        {
            var loan = new Loan();

            Console.WriteLine("Enter Loan Amount");
            loan.Amount = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Loan Duration In Months");
            loan.DurationMonths = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Annual Interest Rate(%)");
            loan.AnnualInterestRate = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Administration Fee(%)");
            loan.AdministrationFeePercentage = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Maximal Administration Fee Amount");
            loan.MaximalAdministrationFeeAmount = int.Parse(Console.ReadLine());

            return loan;
        }
    }
}