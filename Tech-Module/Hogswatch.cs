using System;

namespace Hogswatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int homes = int.Parse(Console.ReadLine());
            int presentsTaken = int.Parse(Console.ReadLine());

            int homesRemaining = homes;
            int visitedHomes = 0;
            int goings = 0;
            int bonusPresents = 0;
            int currentPresents = 0;
            int presents = presentsTaken;
            
            for (int i = 0; i < homes; i++)
            {
                homesRemaining--;
                visitedHomes++;
                int presentsToLeave = int.Parse(Console.ReadLine());
                currentPresents = presents;
                presents -= presentsToLeave;

                if (presents < 0)
                {
                    goings++;
                    int presentsLeft = currentPresents;
                    int additionalPresents = (presentsToLeave - currentPresents);
                    int per = ((presentsTaken / visitedHomes) * homesRemaining + additionalPresents);
                    presents = per - additionalPresents;
                    bonusPresents += per;
                }
            }

            if (goings == 0)
            {
                Console.WriteLine(presents);
            }
            else
            {
                Console.WriteLine(goings);
                Console.WriteLine(bonusPresents);
            }
        }
    }
}
