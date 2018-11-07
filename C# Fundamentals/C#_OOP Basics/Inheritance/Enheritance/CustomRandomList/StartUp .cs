using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var rl = new RandomList();
            Console.WriteLine(rl.RandomInteger());
            rl.Add("ggg");
            rl.Remove(1);
            rl.Add("ttt");

            var test = rl[0]; // Type - Object
            var test1 = rl[1]; // Type - Object
        }
    }
}
