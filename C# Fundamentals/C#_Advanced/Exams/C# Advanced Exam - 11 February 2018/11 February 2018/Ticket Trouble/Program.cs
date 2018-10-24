using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Ticket_Trouble
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> seats = new List<string>();

            string currlyPattern = @"{[^}]*\[([A-Z]{3} [A-Z]{2})\].*?\[([A-Z]{1}[0-9]{1,2})\][^{]*}";
            string squarePattern = @"\[[^\]]*{([A-Z]{3} [A-Z]{2})}.*?{([A-Z]{1}[0-9]{1,2})}[^\[]*\]";

            string destination = Console.ReadLine();
            string input = Console.ReadLine();

            MatchCollection currlyCollection = Regex.Matches(input, currlyPattern);
            MatchCollection squareCollection = Regex.Matches(input, squarePattern);

            AddSeats(currlyCollection, seats, destination);
            AddSeats(squareCollection, seats, destination);

           if(seats.Count == 2)
            {
                Console.WriteLine($"You are traveling to {destination} on seats {seats[0]} and {seats[1]}.");
            }
            else
            {
                for (int i = 0; i < seats.Count; i++)
                {
                    for (int j = i + 1; j < seats.Count; j++)
                    {
                        string firstSeat = seats[i].Substring(1);
                        string secondSeat = seats[j].Substring(1);

                        if(firstSeat == secondSeat)
                        {
                            Console.WriteLine($"You are traveling to {destination} on seats {seats[j]} and {seats[i]}.");
                            return;
                        }
                    }
                }
            }
        }

        private static void AddSeats(MatchCollection collection, List<string> seats, string destination)
        {
            foreach (Match match in collection)
            {
                if (match.Groups[1].Value.Contains(destination))
                {
                    seats.Add(match.Groups[2].Value);
                }
            }
        }
    }
}
