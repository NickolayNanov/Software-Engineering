using System;
using System.Globalization;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            DateModifier.DatesDifference(date1, date2);
        }
    }
}
