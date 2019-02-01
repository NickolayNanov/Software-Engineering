using System;

namespace CustomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CustomCollection<string> list = new CustomCollection<string>();

            string line = Console.ReadLine();
            string element = "";
            int index = default(int);


            while (line != "END")
            {
                string[] tokens = line.Split();
                string command = tokens[0];

                switch (command)
                {
                    case "Add":
                        element = tokens[1];
                        list.Add(element);
                        break;
                    case "Remove":
                        index = int.Parse(tokens[1]);
                        Console.WriteLine(line.Remove(index));
                        break;
                    case "Contains":
                        element = tokens[1];
                        Console.WriteLine(list.Contains(element));
                        break;
                    case "Swap":
                        index = int.Parse(tokens[1]);
                        int index2 = int.Parse(tokens[2]);
                        list.Swap(index, index2);
                        break;
                    case "Greater":
                        element = tokens[1];
                        Console.WriteLine(list.CountGreaterThan(element));
                        break;
                    case "Max":
                        Console.WriteLine(list.Max());
                        break;
                    case "Min":
                        Console.WriteLine(list.Min());
                        break;
                    case "Print":
                        Console.WriteLine(list);
                        break;
                    default: break;
                }

                line = Console.ReadLine();
            }
        }
    }
}
