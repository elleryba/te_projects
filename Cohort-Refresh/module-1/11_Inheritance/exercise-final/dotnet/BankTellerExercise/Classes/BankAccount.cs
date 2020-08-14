namespace BankTellerExercise.Classes
{
    public class BankAccount
    {
        private string accountHolderName;
        public string AccountHolderName
        {
            get { return accountHolderName; }
            private set { accountHolderName = value; }
        }

        private string accountNumber;
        public string AccountNumber
        {
            get { return accountNumber; }
        }

        public decimal Balance { get; private set; }


        // Constructor
        public BankAccount(string accountHolder, string accountNumber)
        {
            this.accountHolderName = accountHolder;
            this.accountNumber = accountNumber;
            this.Balance = 0M;
        }

        public BankAccount(string accountHolder, string accountNumber, decimal balance)
        {
            this.accountHolderName = accountHolder;
            this.accountNumber = accountNumber;
            this.Balance = balance;
        }

        public decimal Deposit(decimal amountToDeposit)
        {
            Balance += amountToDeposit;
            return Balance;
        }

        public virtual decimal Withdraw(decimal amountToWithdraw)
        {
            Balance -= amountToWithdraw;
            return Balance;
        }

    }
}
