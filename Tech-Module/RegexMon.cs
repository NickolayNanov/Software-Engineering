using System;
using System.Text.RegularExpressions;

namespace RegexMon
{
    class Program
    {
        static void Main(string[] args)
        {
            string didiPattern = @"[A-Za-z]+\-[A-Za-z]+";
            string bojoPattern = @"[^A-Za-z\-]+";

            Regex didi = new Regex(didiPattern);
            Regex bojo = new Regex(bojoPattern);


            string input = Console.ReadLine();
            int turns = 1;

            while (true)
            {
                if(turns % 2 != 0)//didi
                {
                    if (!didi.IsMatch(input))
                    {
                        return;
                    }
                    else
                    {
                        Match match = didi.Match(input);
                        input = input.Substring(match.Length, match.Index);
                        Console.WriteLine(match);
                    }
                }
                else//bojo
                {
                    if (!bojo.IsMatch(input))
                    {
                        return;
                    }
                    else
                    {
                        Match match = bojo.Match(input);
                        input = input.Substring(match.Length, match.Index);
                        Console.WriteLine(match);
                    }
                }
                turns++;
            }
        }
    }
}
