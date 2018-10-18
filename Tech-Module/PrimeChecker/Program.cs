using System;

namespace PrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            long num = long.Parse(Console.ReadLine());

            bool prime = IsPrime(num);

            Console.WriteLine(prime);
        }

        static bool IsPrime(long num)
        {
            bool isPrime = true;

            if(num == 0 || num == 1)
            {
                isPrime = false;
            }

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if(num % i == 0)
                {
                    isPrime = false;
                }
            }

            return isPrime;
        }
    }
}
