using System;
using System.Collections.Generic;
using System.Linq;

namespace Hornet_Armada
{
    class Program
    {
        static void Main(string[] args)
        {
            //{lastActivity} = {legionName} -> {soldierType}:{soldierCount}
            //   long           string           string       long

            //{legionName} -> {soldierType}:{soldierCount}
            //{legionName} -> {lastActivity} 

            var legions = new Dictionary<string, Dictionary<string, long>>();
            var legionWithActivities = new Dictionary<string, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new char[] { '=', '-', '>', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int lastActivity = int.Parse(tokens[0]);
                string legionName = tokens[1];
                string soldierType = tokens[2];
                long soldierCount = long.Parse(tokens[3]);

                if (!legionWithActivities.ContainsKey(legionName))
                {
                    legionWithActivities.Add(legionName, lastActivity);
                }
                else
                {
                    if (legionWithActivities[legionName] < lastActivity)
                    {
                        legionWithActivities[legionName] = lastActivity;
                    }
                }

                if (!legions.ContainsKey(legionName))
                {
                    legions.Add(legionName, new Dictionary<string, long>());
                }

                if (!legions[legionName].ContainsKey(soldierType))
                {
                    legions[legionName].Add(soldierType, 0);
                }

                legions[legionName][soldierType] += soldierCount;
            }

            string[] items = Console.ReadLine().Split('\\').ToArray();

            if (items.Length > 1)
            {
                int activity = int.Parse(items[0]);
                string soldierType = items[1];

                foreach (var item in legions
                    .Where(legion => legion.Value.ContainsKey(soldierType))
                    .OrderByDescending(legion => legion.Value[soldierType]))
                {
                    if(legionWithActivities[item.Key] < activity)
                    {
                        Console.WriteLine($"{item.Key} -> {item.Value[soldierType]}");
                    }
                }
            }
            else
            {
                string type = items[0];

                foreach (var item in legionWithActivities.OrderByDescending(x => x.Value))
                {
                    if (legions[item.Key].ContainsKey(type))
                    {
                        Console.WriteLine($"{item.Value} : {item.Key}");
                    }
                }
            }
        }
    }
}
