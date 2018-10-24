using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPrep_11FEB
{
    class Program
    {
        static void Main(string[] args)
        {
            int price = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bulletInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] lockInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int value = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletInput);
            Queue<int> locks = new Queue<int>(lockInput);

            int shots = 0;
            int round = 0;

            bool killLocks = false;
            bool shotsGone = false;
            bool both = false;

            while (true)
            {
                if(bullets.Count == 0 && locks.Count == 0)
                {
                    both = true;
                    break;
                }

                if(bullets.Count == 0)
                {
                    shotsGone = true;
                    break;
                }

                if(round == barrelSize)
                {
                    round = 0;
                    Console.WriteLine("Reloading!");
                    continue;
                }

                if(locks.Count == 0)
                {
                    killLocks = true;
                    break;
                }

                shots++;
                round++;
                int currentBullet = bullets.Pop();
                int currentLock = locks.Peek();

                if(currentBullet > currentLock)
                {
                    Console.WriteLine("Ping!");                    
                }
                else
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
            }

            if (both)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${value - shots * price}");
                return;
            }

            if (killLocks)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${value - shots * price}");
                return;
            }

            if (shotsGone)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                return;
            }

            
        }
    }
}
