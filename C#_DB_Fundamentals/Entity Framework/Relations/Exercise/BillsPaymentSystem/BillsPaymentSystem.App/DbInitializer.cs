namespace BillsPaymentSystem.App
{
    using BillsPaymentSystem.Data;
    using BillsPaymentSystem.Models;
    using BillsPaymentSystem.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class DbInitializer
    {
        public void Seed(BillsPaymentSystemContext context)
        {
            //SeedUsers(context);
            //SeedCreditCards(context);
            //SeedBankAccounts(context);
            //SeedPaymentMethod(context);
        }
       
        //BE CAREFULL WITH THE RELATIONSHIPS!!!!!!!!!!! Change CreditCardId and BankAccountId however serves you well.
        private static void SeedPaymentMethod(BillsPaymentSystemContext context)
        {
            var paymentMethods = new List<PaymentMethod>();
            PaymentMethod paymentMethod;

            for (int i = 1; i <= 3; i++)
            {
                paymentMethod = new PaymentMethod()
                {
                    UserId = new Random().Next(49, 55),
                    Type = (PaymentType)new Random().Next(0, 2)
                };

                if(i == 1)
                {
                    paymentMethod.CreditCardId = 1;
                }
                else if(i == 2)
                {
                    paymentMethod.BankAccountId = 2;
                }
                else if(i == 3)
                {
                    paymentMethod.BankAccountId = 2;
                    paymentMethod.CreditCardId = 2;
                }

                if (!IsValid(paymentMethod)) continue;

                paymentMethods.Add(paymentMethod);
            }

            context.PaymentMethods.AddRange(paymentMethods);
            context.SaveChanges();
        }

        private static void SeedBankAccounts(BillsPaymentSystemContext context)
        {
            var bankAccounts = new List<BankAccount>();

            BankAccount bankAccount = new BankAccount();

            decimal balance = 500;
            string[] bankNames = { "Central Bank", "Dsk", "OBB" };
            string[] swifts = { "1342354", "2454254", "134523" };

            for (int i = 0; i < 3; i++)
            {
                bankAccount = new BankAccount()
                {
                    Balance = balance,
                    BankName = bankNames[i],
                    SWIFT = swifts[i]
                };

                if (!IsValid(bankAccount)) continue;

                bankAccounts.Add(bankAccount);

                balance += 150;
            }

            context.BankAccounts.AddRange(bankAccounts);
            context.SaveChanges();
        }

        private static void SeedCreditCards(BillsPaymentSystemContext context)
        {
            var creditCards = new List<CreditCard>();
            decimal limit = 300;
            decimal moneyOwed = 100;
            int days = 60;

            CreditCard creditCard;

            for (int i = 0; i < 3; i++)
            {
                creditCard = new CreditCard()
                {
                    Limit = limit,
                    MoneyOwed = moneyOwed,
                    ExpirationDate = DateTime.Now.AddDays(days)
                };

                if (!IsValid(creditCard)) continue;

                creditCards.Add(creditCard);

                limit += 50;
                moneyOwed += 70;
                days += 10;
            }

            context.CreditCards.AddRange(creditCards);
            context.SaveChanges();
        }

        private static void SeedUsers(BillsPaymentSystemContext context)
        {
            string[] firstNames = { "Gosho", "Ivan", "Kiro", null, "" };
            string[] lastNames = { "Goshev", "Ivanov", "Kirov", null, "" };
            string[] emails = { "gosho@abv.bg", "ivan@abv.bg", "kiro@abv.bg", null, "ERROR" };
            string[] passwords = { "12@abv.bg", "ivan@333.bg", "4133@abv.bg", null, "33" };

            List<User> users = new List<User>();

            for (int i = 0; i < firstNames.Length; i++)
            {
                var user = new User()
                {
                    FirstName = firstNames[i],
                    LastName = lastNames[i],
                    Email = emails[i],
                    Password = passwords[i]
                };

                if (IsValid(user))
                {
                    users.Add(user);
                }
            }

            context.Users.AddRange(users);
            context.SaveChanges();
        }



        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator
                                .TryValidateObject(entity,
                                                   validationContext,
                                                   validationResults,
                                                   true);

            return isValid;
        }
    }
}
