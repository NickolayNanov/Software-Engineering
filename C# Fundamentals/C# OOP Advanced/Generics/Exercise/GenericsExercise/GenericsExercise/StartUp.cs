using System;

namespace GenericsExercise
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++) 
            {
                string input = Console.ReadLine();
                var box = new Box<string>(input);

                Console.WriteLine(box);
            }
        }
    }
}
