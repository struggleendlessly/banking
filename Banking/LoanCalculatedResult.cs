using System;

namespace Banking
{
    /// <summary>
    /// Represents loan calculation. Also provides method for calculation.
    /// </summary>
    public class LoanCalculatedResult
    {
        public double MonthlyLoanAmount { get; set; }

        public double TotalPayment { get; set; }

        public double TotalInterestRateAmount { get; set; }

        public double AdministrationFeeAmount { get; set; }

        public double MonthlyInterestRate { get; set; }

        /// <summary>
        /// Make calculations of the loan and returns calculated results such as total payment, monthly payment, total interest amount and administration fee(one-time) amount.
        /// </summary>
        /// <param name="loan">Model with terms for the loan. Typeof <see cref="Loan"/>.</param>
        /// <returns>Returns model typeof <see cref="LoanCalculatedResult"/>.</returns>
        public static LoanCalculatedResult Calculate(Loan loan)
        {
            var loanResult = new LoanCalculatedResult
            {
                MonthlyInterestRate = loan.AnnualInterestRate / 100 / 12
            };

            loanResult.MonthlyLoanAmount = loan.Amount * (loanResult.MonthlyInterestRate + 
                (loanResult.MonthlyInterestRate / (Math.Pow(1 + loanResult.MonthlyInterestRate, loan.DurationMonths) - 1)));
            loanResult.TotalPayment = loanResult.MonthlyLoanAmount * loan.DurationMonths;
            loanResult.TotalInterestRateAmount = loanResult.TotalPayment - loan.Amount;
            loanResult.AdministrationFeeAmount = ((loan.Amount * loan.AdministrationFeePercentage / 100) > loan.MaximalAdministrationFeeAmount) ?
                loan.MaximalAdministrationFeeAmount : loan.Amount * loan.AdministrationFeePercentage / 100;

            return loanResult;
        }

        /// <summary>
        /// Prints results into console.
        /// </summary>
        public void PrintResults()
        {
            Console.WriteLine($"Total payment: {TotalPayment}");
            Console.WriteLine($"Total interest: {TotalInterestRateAmount}");
            Console.WriteLine($"Monthly payment: {MonthlyLoanAmount}");
            Console.WriteLine($"+ Administration Fee(one-time) Amount: {AdministrationFeeAmount}");
        }
    }
}