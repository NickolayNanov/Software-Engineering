using System;

namespace Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long rows = int.Parse(Console.ReadLine());

            triangle(rows);
        }
        public static void triangle(long maxRows)
        {
            long r, num;
            for (int i = 0; i <= maxRows - 1; i++)
            {
                num = 1;
                r = i + 1;
                //pre-spacing
                
                for (int col = 0; col <= i; col++)
                {
                    if (col > 0)
                    {
                        num = num * (r - col) / col;
                    }
                    Console.Write(num + " ");
                }
                Console.WriteLine(); ;
            }
        }
    }
}
