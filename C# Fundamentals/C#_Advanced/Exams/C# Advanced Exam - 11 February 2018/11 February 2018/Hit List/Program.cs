using System;
using System.Collections.Generic;
using System.Linq;

namespace Hit_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>> info = new Dictionary<string, Dictionary<string, string>>();

            int targetInfoIndex = int.Parse(Console.ReadLine());

            string line = Console.ReadLine();

            while(line != "end transmissions")
            {
                string[] tokens = line.Split(new char[] { '='}, StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];

                if (!info.ContainsKey(name))
                {
                    info.Add(name, new Dictionary<string, string>());
                }

                string[] values = tokens[1].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var val in values)
                {
                    string[] items = val.Split(':', StringSplitOptions.RemoveEmptyEntries);

                    string property = items[0];
                    string value = items[1];

                    if (!info[name].ContainsKey(property))
                    {
                        info[name].Add(property, value);
                    }
                    else
                    {
                        info[name][property] = value;
                    }
                }
                line = Console.ReadLine();
            }

            string[] killCommand = Console.ReadLine().Split();

            string chosen = killCommand[1];

            KeyValuePair<string, Dictionary<string, string>> resultInfo = info.First(x => x.Key == chosen);

            int index = 0;

            foreach (var keyVal in resultInfo.Value)
            {
                index += keyVal.Key.Length;
                index += keyVal.Value.Length;
            }

            Console.WriteLine($"Info on {resultInfo.Key}:");
            foreach (var prop in resultInfo.Value.OrderBy(x => x.Key))
            {
                Console.WriteLine($"---{prop.Key}: {prop.Value}");
            }
            Console.WriteLine("Info index: {0}", index);

            if(index >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex - index} more info.");
            }
        }
    }
}
