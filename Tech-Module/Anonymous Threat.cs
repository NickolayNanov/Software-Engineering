using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "3:1")
                {
                    break;
                }

                string[] tokens = line.Split().ToArray();

                string command = tokens[0];

                if(command == "merge")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    input = Merge(input, startIndex, endIndex);
                }
                else if(command == "divide")
                {
                    int index = int.Parse(tokens[1]);
                    int parts = int.Parse(tokens[2]);

                    input = Divide(input, index, parts);
                }
            }
            Console.WriteLine(string.Join(" ", input));
        }

        private static int isValidIndex(int index, int maxIndex)
        { 
            if(index < 0)
            {
                index = 0;
            }
            else if(index >= maxIndex - 1)
            {
                index = maxIndex - 1;
            }

            return index;
        }

        private static List<string> Merge(List<string> line, int startIndex, int endIndex)
        {
            List<string> newList = new List<string>();

            startIndex = isValidIndex(startIndex, line.Count);
            endIndex = isValidIndex(endIndex, line.Count);

            for (int i = 0; i < startIndex; i++)
            {
                newList.Add(line[i]);
            }

            StringBuilder sb = new StringBuilder();

            for (int i = startIndex; i <= endIndex; i++)
            {
                sb.Append(line[i]);
            }

            newList.Add(sb.ToString());

            for (int i = endIndex + 1; i < line.Count; i++)
            {
                newList.Add(line[i]);
            }

            return newList;
        }

        private static List<string> Divide (List<string> line, int index, int parts)
        {
            string element = line[index];
            int partsLength = element.Length / parts;

            List<string> divided = new List<string>();

            for (int i = 0; i < parts; i++)
            {
                if(i == parts - 1)
                {
                    divided.Add(element.Substring(i * partsLength));
                }
                else
                {
                    divided.Add(element.Substring(i * partsLength, partsLength));
                }
            }

            line.RemoveAt(index);
            line.InsertRange(index, divided);
            return line;
        } 
    }
}
