namespace BankTellerExercise.Classes
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string accountHolder, string accountNumber, decimal balance)
            :base(accountHolder, accountNumber, balance)
        {
        }

        public SavingsAccount(string accountHolder, string accountNumber)
            : base(accountHolder, accountNumber)
        { }

        public override decimal Withdraw(decimal amountToWithdraw)
        {
            // only perform transaction of positive $ and room for fee
            if ((Balance - amountToWithdraw) >= 2)
            {
                base.Withdraw(amountToWithdraw);

                // Assess $2 fee if it goes below $150
                if (Balance < 150M)
                {
                    base.Withdraw(2.0M);
                }
            }

            return Balance;

        }
    }
}
