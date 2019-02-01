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
                int input = int.Parse(Console.ReadLine());
                var box = new Box<int>(input);

                Console.WriteLine(box);
            }
        }
    }
}
