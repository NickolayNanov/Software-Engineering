using System;
using System.Linq;

namespace Parking_Feud
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[][] parking = CreateParking();

            int entrance = int.Parse(Console.ReadLine());

            TryPark(entrance, parking);

        }

        private static void TryPark(int entrance, bool[][] parking)
        {
            string[] places = Console.ReadLine().Split();
            bool parked = false;
            string parkingPlace = places[0];

            
            
        }

        private static bool[][] CreateParking()
        {
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int actualRows = parameters[0] * 2 - 1;
            int actualCols = parameters[1] + 2;

            bool[][] parking = new bool[actualRows][];

            for (int row = 0; row < parking.Length; row++)
            {
                parking[row] = new bool[actualCols];
            }

            return parking;
        }
    }
}
