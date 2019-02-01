using System;

namespace Testing
{
    public class BankAccount
    {
        public BankAccount()
        {

        }

        public decimal Amount { get; set; }

        public void Deposit(decimal amount)
        {
            this.Amount += amount;
        }

        public void WithDraw(decimal amount)
        {
            this.Amount -= amount;
        }
    }
}
