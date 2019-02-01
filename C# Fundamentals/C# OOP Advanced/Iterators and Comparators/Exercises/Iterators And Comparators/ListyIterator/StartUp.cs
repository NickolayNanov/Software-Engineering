namespace ListyIterator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static ListyIterator<string> list;

        public static void Main(string[] args)
        {

            int[] array = new int[] { 1, 2, 3, 4 };

            Stack<int> numbs = new Stack<int>(array);

            numbs.Pop();
            numbs.Pop();


            string[] names = new string[] { "Niki", "Ici"};

            Stack<string> stack = new Stack<string>(names);
            var ele = stack.Pop();

            string line = Console.ReadLine();
            
            while (line != "END")
            {
                string[] tokens = line.Split();
                string command = tokens[0];

                switch (command)
                {
                    case "Create":
                        string[] elements = tokens.Skip(1).ToArray();
                        list = new ListyIterator<string>(elements);
                        break;
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "PrintAll":
                        list.PrintAll();
                        break;
                    case "Print":

                        try
                        {
                            list.Print();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;                    
                }

                line = Console.ReadLine();
            }
        }
    }
}
