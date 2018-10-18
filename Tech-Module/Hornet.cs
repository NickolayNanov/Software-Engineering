using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Hornet_Comm
{
    class Program
    {
        static void Main(string[] args)
        {
            string messagePattern = @"^(\d)+ \<\-\> [A-Za-z0-9]+$";
            string broadcastPattern = @"^(\D)+ \<\-\> [A-Za-z0-9]+$";

             Regex message = new Regex(messagePattern);
            Regex broadcast = new Regex(broadcastPattern);

            List<string> messages = new List<string>();
            List<string> broadcasts = new List<string>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Hornet is Green")
                {
                    break;
                }

                if (message.IsMatch(line))//private
                {
                    string[] tokens = line.Split(new char[] { '<', '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string recipentCode = tokens[0];
                    string messagge = tokens[1];
                    string toAdd = $"{string.Join("", recipentCode.Reverse()).ToString()} -> {messagge}";

                    messages.Add(toAdd);
                }
                else if (broadcast.IsMatch(line))//broadcast
                {
                    string[] tokens = line.Split(" <-> ").ToArray();

                    string frequency = tokens[0];
                    string messsage = Decript(tokens[1]);

                    string toAdd = $"{messsage} -> {frequency}";

                    broadcasts.Add(toAdd);
                }
            }

            Console.WriteLine("Broadcasts:");
            if(broadcasts.Count > 0)
            {
                Console.WriteLine(string.Join("\n", broadcasts));
            }
            else
            {
                Console.WriteLine("None");
            }

            Console.WriteLine("Messages:");
            if (messages.Count > 0)
            {
                Console.WriteLine(string.Join("\n", messages));
            }
            else
            {
                Console.WriteLine("None");
            }
        }

        public static string Decript(string str)
        {
            string message = "";

            foreach (var ch in str)
            {
                if(ch >= 97 && ch <= 122)
                {
                    message += (char)(ch + 32);
                }
                else if(ch >= 65 && ch <= 90)
                {
                    message += (char)(ch - 32);
                }
                else
                {
                    message += ch;
                }
            }

            return message;
        }
    }
}
