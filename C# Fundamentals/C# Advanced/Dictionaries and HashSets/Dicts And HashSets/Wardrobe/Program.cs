using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
        static string colour;
        static string dress;

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new string[] { " -> "}, StringSplitOptions.RemoveEmptyEntries);

                string colour = tokens[0];
                List<string> current = tokens[1].Split(',').ToList();

                if (!wardrobe.ContainsKey(colour))
                {
                    wardrobe.Add(colour, new Dictionary<string, int>());
                }


                for (int colth = 0; colth < current.Count; colth++)
                {
                    if (!wardrobe[colour].ContainsKey(current[colth]))
                    {
                        wardrobe[colour].Add(current[colth], 1);
                    }
                    else
                    {
                        wardrobe[colour][current[colth]]++;
                    }
                }                
            }

            string[] items = Console.ReadLine().Split();

            colour = items[0];
            dress = items[1];
            
            foreach (var cl in wardrobe)
            {
                Console.WriteLine($"{cl.Key} clothes:");

                foreach (var dr in cl.Value)
                {

                    if(cl.Key == colour && dr.Key == dress)
                    {
                        Console.WriteLine($"* {dr.Key} - {dr.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {dr.Key} - {dr.Value}");
                    }                   
                }
            }
        }
    }
}
