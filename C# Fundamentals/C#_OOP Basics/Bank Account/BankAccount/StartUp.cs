using System;
using System.Collections.Generic;

namespace BankAccount
{
    public class StartUp 
    {
        static void Main(string[] args)
        {
            Person person = new Person("Niki", 18);

            for (int i = 1; i <= 3; i++)
            {
                person.Accounts.Add(new BankAccount {Id = i, Balance = 10 * i});
            }

            Console.WriteLine($"{person.GetBalance():f2}");
        }
    }
}
