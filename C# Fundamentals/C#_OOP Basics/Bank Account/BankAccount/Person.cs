using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount
{
    public class Person
    {
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
            this.accounts = new List<BankAccount>();
        }

        public Person(string name, int age, List<BankAccount> accounts)
        {
            this.name = name;
            this.age = age;
            this.accounts = accounts;
        }

        private string name;
        private int age;
        private List<BankAccount> accounts;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                age = value;
            }
        }
        
        public List<BankAccount> Accounts
        {
            get
            {
                return this.accounts;
            }
            set
            {
                accounts = value;
            }
        }

        public decimal GetBalance()
        {
            decimal balance = 0.0m;

            for (int i = 0; i < this.accounts.Count; i++)
            {
                balance += this.accounts[i].Balance;
            }
            return balance;
        }
    }
}
