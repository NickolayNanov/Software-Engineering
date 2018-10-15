using System;
using System.Text;

namespace CountSubstringOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = Console.ReadLine();

            int count = 0;
            int index = 0;

            while (true)
            {
                index = text.IndexOf(pattern, index);

                if(index <= 0)
                {
                    break;
                }
                count++;
                index++;
            }

            Console.WriteLine(count);

        }
    }
}
