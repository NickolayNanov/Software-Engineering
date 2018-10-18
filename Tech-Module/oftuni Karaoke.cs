using System;
using System.Collections.Generic;
using System.Linq;

namespace Softuni_Karaoke
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

            List<string> participants = Console.ReadLine()
                .Split(", ")
                .ToList();

            List<string> songs = Console.ReadLine()
                .Split(", ")
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "dawn") break;

                string[] tokens = line.Split(", ");

                string singer = tokens[0];
                string song = tokens[1];
                string award = tokens[2];

                if(participants.Contains(singer) && songs.Contains(song))
                {
                    if (!result.ContainsKey(singer))
                    {
                        result.Add(singer, new List<string>());
                    }

                    if (!result[singer].Contains(award))
                    {
                        result[singer].Add(award);
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            if(result.Count == 0)
            {
                Console.WriteLine("No awards");
                return;
            }

            foreach (var item in result.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");

                foreach ( var award in item.Value)
                {
                    Console.WriteLine("--" + award);
                }
            } 
        }
    }
}
