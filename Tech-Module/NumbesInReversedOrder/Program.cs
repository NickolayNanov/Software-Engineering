using System;

namespace NumbesInReversedOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            string result = ReverseNumber(number);
            Console.WriteLine(result);
        }

        static string ReverseNumber(string num)
        {
            string reversed = String.Empty;

            for (int index = num.Length - 1; index >= 0; index--)
            {
                reversed += num[index];
            }

            return reversed;
        }
    }
}
