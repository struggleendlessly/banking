using System;

namespace Banking
{
    class Program
    {
        static void Main(string[] args)
        {
            var loan = Loan.GetLoanData();

            var calculatedResult = LoanCalculatedResult.Calculate(loan);

            calculatedResult.PrintResults();

            Console.ReadLine();
        }
    }
}
