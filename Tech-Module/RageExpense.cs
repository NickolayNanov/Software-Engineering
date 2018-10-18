using System;

namespace Rage_Expense
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            decimal headsetPrice = decimal.Parse(Console.ReadLine());
            decimal mousePrice = decimal.Parse(Console.ReadLine());
            decimal keyboardPrice = decimal.Parse(Console.ReadLine());
            decimal displayPrice = decimal.Parse(Console.ReadLine());

            int headsets = lostGames / 2;
            int mouses = lostGames / 3;
            int keyboadrs = lostGames / 6;
            int displays = keyboadrs / 2;

            decimal result = (headsetPrice * headsets) + (mousePrice * mouses)
                + (keyboardPrice * keyboadrs) + (displayPrice * displays);

            Console.WriteLine($"Rage expenses: {result:f2} lv.");
        }
    }
}
