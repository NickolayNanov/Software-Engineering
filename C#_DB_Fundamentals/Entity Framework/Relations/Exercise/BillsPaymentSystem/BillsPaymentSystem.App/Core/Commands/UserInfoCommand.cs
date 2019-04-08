namespace BillsPaymentSystem.App.Core.Commands
{
    using BillsPaymentSystem.App.Core.Commands.Contracts;
    using BillsPaymentSystem.Data;
    using BillsPaymentSystem.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class UserInfoCommand : ICommand
    {
        private readonly BillsPaymentSystemContext context;
        private readonly StringBuilder sb;

        public UserInfoCommand(BillsPaymentSystemContext context)
        {
            this.context = context;

            this.sb = new StringBuilder();
        }

        public string Execute(string[] args)
        {
            int userId = int.Parse(args[0]);

            User user = this.context
                                .Users                                
                                .FirstOrDefault(u => u.UserId == userId);

            context.Entry(user).Collection(u => u.PaymentMethods);
         
            if (user == null)
            {
                throw new ArgumentNullException($"User with id {userId} not found!");
            }

            sb.AppendLine($"User: {user.FullName}");

            List<BankAccount> bankAccounts = context
                                                 .PaymentMethods
                                                 .Include(ba => ba.BankAccount)
                                                 .Where(pm => pm.UserId == userId)
                                                 .Select(u => u.BankAccount)
                                                 .ToList();

            List<CreditCard> creditCards = context
                                               .PaymentMethods
                                               .Include(cc => cc.CreditCard)
                                               .Where(pm => pm.UserId == userId)
                                               .Select(u => u.CreditCard)
                                               .ToList();


            CheckBankAccounts(bankAccounts);
            CheckCreditCards(creditCards);

            return this.sb.ToString();
        }

        private void CheckCreditCards(List<CreditCard> userCreditCards)
        {
            userCreditCards = userCreditCards.Where(cc => cc != null).ToList();

            if (userCreditCards.Count == 0)
            {
                sb.AppendLine($"User doesn not own any credit cards!");
            }
            else
            {
                sb.AppendLine("Credit Cards:");

                AppendCreditCards(userCreditCards);
            }
        }

        private void AppendCreditCards(List<CreditCard> userCreditCards)
        {
            foreach (CreditCard creditCard in userCreditCards)
            {
                sb.AppendLine(Environment.NewLine);
                sb.AppendLine($"-- ID: {creditCard.CreditCardId} {Environment.NewLine}" +
                                    $"--- Limit: {creditCard.Limit:F2} {Environment.NewLine}" +
                                    $"--- Money Owed: {creditCard.MoneyOwed:F2} {Environment.NewLine}" +
                                    $"--- Limit Left:: {creditCard.LimitLeft:F2} {Environment.NewLine}" +
                                    $@"--- Expiration Date: {creditCard.ExpirationDate           
                                                                .ToString(CultureInfo.InvariantCulture.DateTimeFormat)}");               
            }
        }

        private void CheckBankAccounts(List<BankAccount> userBankAccounts)
        {
            userBankAccounts = userBankAccounts.Where(ba => ba != null).ToList();
            if (userBankAccounts.Count == 0)
            {
                sb.AppendLine("User does not own any bank accounts");
            }
            else
            {
                sb.AppendLine("Bank Accounts:");
                AppendBankAccounts(userBankAccounts);
            }
        }

        private void AppendBankAccounts(List<BankAccount> userBankAccounts)
        {
            foreach (var bankAccount in userBankAccounts)
            {
                sb.AppendLine(Environment.NewLine);

                sb.AppendLine($"-- ID: {bankAccount.BankAccountId} {Environment.NewLine}" + 
                                $"--- Balance: {bankAccount.Balance:F2} {Environment.NewLine}"+
                                 $"--- Bank: {bankAccount.BankName} {Environment.NewLine}" +
                                 $"--- SWIFT: {bankAccount.SWIFT} {Environment.NewLine}");
            }
        }
    }
}
