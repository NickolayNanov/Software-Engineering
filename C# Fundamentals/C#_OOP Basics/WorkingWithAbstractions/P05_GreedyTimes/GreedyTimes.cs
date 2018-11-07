using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());
            string[] locker = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            bag.Add("Cash", new Dictionary<string, long>());
            bag.Add("Gold", new Dictionary<string, long>());
            bag.Add("Gem", new Dictionary<string, long>());
            
            long gold = 0;
            long gems = 0;
            long money = 0;

            for (int i = 0; i < locker.Length; i += 2)
            {
                string name = locker[i];
                long count = long.Parse(locker[i + 1]);
                string item = GetItem(name, count);

                if (!bag.ContainsKey(item))
                {
                    bag[item] = new Dictionary<string, long>();
                }

                if (!bag[item].ContainsKey(name))
                {
                    bag[item][name] = 0;
                }

                bag[item][name] += count;

                switch (item)
                {
                    case "Gem":
                        if (!bag.ContainsKey(item))
                        {
                            if (bag.ContainsKey("Cash"))
                            {
                                if (count > bag["Cash"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[item].Values.Sum() > bag["Gold"].Values.Sum())
                        {                       
                            bag[item][name] -= count;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(item))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (count > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[item].Values.Sum() > bag["Gem"].Values.Sum())
                        {
                            bag[item][name] -= count;
                        }
                        break;
                }

                if (item == "Gold")
                {
                    gold += count;
                }
                else if (item == "Gem")
                {
                    gems += count;
                }
                else if (item == "Cash")
                {
                    money += count;
                }
            }

            foreach (var b in bag.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Key))
            {
                if(b.Value.Values.Sum() == 0)
                {
                    continue;
                }
                Console.WriteLine($"<{b.Key}> ${b.Value.Values.Sum()}");
                foreach (var item2 in b.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    if(item2.Value == 0)
                    {
                        continue;
                    }
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }

        private static string GetItem(string name, long count)
        {
            string item = string.Empty;

            if (name.Length == 3)
            {
                item = "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                item = "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                item = "Gold";
            }
            
            return item;
        }
    }
}