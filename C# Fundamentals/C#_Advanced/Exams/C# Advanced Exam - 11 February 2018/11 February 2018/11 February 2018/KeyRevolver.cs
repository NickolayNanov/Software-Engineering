using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_February_2018
{
    class KeyRevolver
    {
        static int bulletPrice;
        static int barelSize;
        static Stack<int> bullets;
        static Queue<int> locks;
        static int intelligenceValue;

        static void Main(string[] args)
        {
            bulletPrice = int.Parse(Console.ReadLine());
            barelSize = int.Parse(Console.ReadLine());
            int[] bulletts = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] loccks = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bullets = new Stack<int>(bulletts);
            locks = new Queue<int>(loccks);

            intelligenceValue = int.Parse(Console.ReadLine());

            int round = 0;
            int shots = 0;

            bool LocksFinish = false;
            bool bulll = false;

            while(true)
            {

                if(bullets.Count == 0 && locks.Count == 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue - shots * bulletPrice}");
                    return;
                }

                if (bullets.Count == 0)
                {
                    bulll = true;
                    break;
                }

                if (barelSize == round)
                {
                    Console.WriteLine("Reloading!");
                    round = 0;
                    continue;
                }

                if(locks.Count == 0)
                {
                    LocksFinish = true;
                    break;
                }

                int currentBullet = bullets.Pop();
                int currentLock = locks.Peek();               
                
                if(currentLock >= currentBullet)
                {
                    Console.WriteLine("Bang!");
                    round++;
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                    round++;                    
                }
                shots++;
            }


            if (bulll)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                return;
            }
            if (LocksFinish)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue - shots * bulletPrice}");
                return;
            }

           
        }
    }
}
