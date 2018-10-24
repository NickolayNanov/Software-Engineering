using System;
using System.Collections.Generic;
using System.Linq;

class Greedy_times
{
    static void Main(string[] args)
    {
        Dictionary<string, long> bag = new Dictionary<string, long>();


        int capacity = int.Parse(Console.ReadLine());

        string[] data = Console.ReadLine().Split();

        Queue<string> tokens = new Queue<string>(data);

        while(tokens.Count != 0)
        {
            string item = tokens.Dequeue();
            int quantity = int.Parse(tokens.Dequeue());


        }
    }
}