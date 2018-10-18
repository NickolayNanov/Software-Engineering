using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "course start")
                {
                    break;
                }

                string[] tokens = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string lesson = tokens[1];

                if (command == "Add")
                {
                    if (!input.Contains(lesson))
                    {
                        input.Add(lesson);
                    }
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(tokens[2]);

                    if (!input.Contains(lesson))
                    {
                        input.Insert(index, lesson);
                    }
                }
                else if (command == "Remove")
                {
                    if (input.Contains(lesson))
                    {
                        input.Remove(lesson);
                    }
                }
                else if (command == "Exercise")
                {
                    if (!input.Contains(lesson))
                    {
                        input.Add(lesson);
                        if (!input.Contains($"{lesson}-Exercise"))
                        {
                            int indexOfLesson = input.IndexOf(lesson);

                            input.Insert(indexOfLesson + 1, $"{lesson}-Exercise");
                        }
                    }
                    else
                    {
                        if (!input.Contains($"{lesson}-Exercise"))
                        {
                            int indexOfLesson = input.IndexOf(lesson);

                            input.Insert(indexOfLesson + 1, $"{lesson}-Exercise");
                        }
                    }
                }
                else if (command == "Swap")
                {
                    string first = tokens[1];
                    string second = tokens[2];

                    if (input.Contains(first) && input.Contains(second))
                    {
                        if (!input.Contains($"{first}-Exercise") && !input.Contains($"{second}-Exercise"))
                        {
                            int indexOfFirst = input.IndexOf(first);
                            int indexOfSecond = input.IndexOf(second);

                            input.RemoveAt(indexOfFirst);
                            input.Insert(indexOfFirst, second);

                            input.RemoveAt(indexOfSecond);
                            input.Insert(indexOfSecond, first);
                        }
                        else
                        {
                            int indexOfFirst = input.IndexOf(first);
                            int indexOfSecond = input.IndexOf(second);
                            int indexOfSecondEx = input.IndexOf($"{second}-Exercise");

                            input.RemoveAt(indexOfFirst);

                            input.Insert(indexOfFirst, second);
                            input.Insert(indexOfFirst + 1, $"{second}-Exercise");     
                            
                            input.RemoveAt(indexOfSecond + 1);
                            input.RemoveAt(indexOfSecondEx);       
                            
                            input.Insert(indexOfSecond + 1, first);
                        }
                    }
                }               
            }

            int number = 0;
            foreach (var course in input)
            {
                Console.WriteLine($"{++number}.{course}");
            }
        }
    }
}
