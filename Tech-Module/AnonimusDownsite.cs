using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AnonimusDownsite
{
    class Program
    {
        static void Main(string[] args)
        {
            long sitesCount = long.Parse(Console.ReadLine());
            long securityKey = long.Parse(Console.ReadLine());

            List<string> sites = new List<string>();

            decimal totalMoneyLoss = 0.0M;

            for (int i = 0; i < sitesCount; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();

                string site = input[0];
                long sitesVisits = long.Parse(input[1]);
                decimal comersialPrice = decimal.Parse(input[2]);

                totalMoneyLoss += sitesVisits * comersialPrice;

                sites.Add(site);
            }

            BigInteger securityToken = BigInteger.Pow(securityKey, sites.Count); 

            foreach (var site in sites)
            {
                Console.WriteLine(site);
            }

            Console.WriteLine($"Total Loss: {totalMoneyLoss:f20}");
            Console.WriteLine($"Security Token: {securityToken}");

        }
    }
}
