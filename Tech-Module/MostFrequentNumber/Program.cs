using System;
using System.Linq;

namespace MostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            int mostlyOccured = 0;
            int totalOccurances = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentOccurances = 0;
                int currentNumber = numbers[i];

                for (int j = i; j < numbers.Length; j++)
                {
                    if(currentNumber == numbers[j])
                    {
                        currentOccurances++;
                        if(currentOccurances > totalOccurances)
                        {
                            totalOccurances = currentOccurances;
                            mostlyOccured = currentNumber;
                        }
                    }
                }     
            }
            Console.WriteLine(mostlyOccured);
        }
    }
}
