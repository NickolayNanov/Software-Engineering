using System;

namespace Mordor_sCruelPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] commands = Console.ReadLine()
                .Split(new char[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries);

            Mood mood = new Mood(commands);
            Console.WriteLine(mood.CurrentMood);
        }
    }
}
