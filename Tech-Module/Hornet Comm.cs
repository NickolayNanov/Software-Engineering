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

                if(line == "Hornet is Green")
                {
                    break;
                }

                if (message.IsMatch(line))//private
                {
                    string[] tokens = line.Split(" <-> ").ToArray();

                    string recipentCode = tokens[0].Reverse();
                    string message = tokens[1];
                    string toAdd = $"{recipentCode} -> {message}";

                    messages.Add(toAdd);
                }
                else if (broadcast.IsMatch(line))//broadcast
                {

                }

                
            }
        }
    }
}
