using System;
using System.Collections.Generic;
using System.Linq;

namespace HandsOfPlayers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> players = new Dictionary<string, List<string>>();

            string line;

            while ((line = Console.ReadLine()) != "JOKER")
            {
                string[] tokens = line.Split(':');

                string playerName = tokens[0];
                string[] cards = tokens[1].Trim().Split(", ").ToArray();

                if (!players.ContainsKey(playerName))
                {
                    players.Add(playerName, new List<string>());
                }

                players[playerName].AddRange(cards);

            }
            Dictionary<string, int> powers = new Dictionary<string, int>();

            for (int i = 2; i <= 9; i++)
            {
                int power = i;
                string powerStr = i.ToString();

                powers.Add(powerStr, power);
            }

           
            powers.Add("J", 11);
            powers.Add("Q", 12);
            powers.Add("K", 13);
            powers.Add("A", 14);

            powers.Add("1", 10);
            powers.Add("S", 4);
            powers.Add("H", 3);
            powers.Add("D", 2);
            powers.Add("C", 1);

            foreach (var player in players)
            {
                List<string> playerCards = player.Value.Distinct().ToList();

                int sum = 0;

                foreach (var card in playerCards)
                {
                    string cardsPowerStr = card[0].ToString();
                    string cardsSuitStr = card[card.Length - 1].ToString();

                    int cardPower = powers[cardsPowerStr];
                    int cardSuit = powers[cardsSuitStr];

                    sum += cardPower * cardSuit;
                }

                Console.WriteLine($"{player.Key}: {sum}");
            }

        }
    }

}
