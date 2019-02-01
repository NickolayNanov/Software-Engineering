using System;

namespace Testing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            GenericCollection<int> numbers = new GenericCollection<int>();

            numbers.Add(1);
            numbers.Add(1);
            numbers.Add(1);
            numbers.Add(1);

            Console.WriteLine(string.Join("", numbers));
   
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}
