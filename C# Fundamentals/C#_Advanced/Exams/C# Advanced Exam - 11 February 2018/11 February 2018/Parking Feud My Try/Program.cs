using System;
using System.Linq;

namespace Parking_Feud_My_Try
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[][] parking = CreateParking();

            int entrance = int.Parse(Console.ReadLine());

            TryPark(parking, entrance);
        }

        private static void TryPark(bool[][] parking, int entrance)
        {
            bool parked = false;
            int maxColumnIndex = parking[0].Length - 1;
            int totaDistance = 0;
            string parkingSpot = String.Empty;

            while (!parked)
            {
                string[] tokens = Console.ReadLine().Split();
                int index = entrance - 1;

                parkingSpot = tokens[index];

                int conflict = -1;

                for (int i = 0; i < tokens.Length; i++)
                {
                    if(parkingSpot == tokens[i] && index != i)
                    {
                        conflict = i;
                    }
                }

                int currentDistance = CalculateDistence(parkingSpot, entrance, maxColumnIndex);
                totaDistance += currentDistance;

                if(conflict >= 0)
                {
                    int otherCarDistance = CalculateDistence(tokens[conflict], conflict + 1, maxColumnIndex);
                
                    if(currentDistance > otherCarDistance)
                    {
                        totaDistance += currentDistance;
                    }
                    else
                    {
                        parked = true;
                    }
                    
                }
                else
                {
                    parked = true;
                }
            }

            Console.WriteLine($"Parked successfully at {parkingSpot}.");
            Console.WriteLine($"Total Distance Passed: {totaDistance}");
        }

        private static int CalculateDistence(string parkingSpot, int entrance, int maxColumnIndex)
        {
            bool goingLeft = true;
            int[] currentPosition = new int[] { entrance * 2 - 1, 0 };
            int[] parkingPositon = GetParkingPosition(parkingSpot);
            int distance = 0;

            while(!AtSpot(currentPosition, parkingPositon))
            {
                distance++;

                currentPosition[1] += goingLeft ? 1 : -1;

                bool reachedTheEnd = currentPosition[1] == maxColumnIndex && goingLeft ||
                   currentPosition[1] == 0 && !goingLeft;

                if (reachedTheEnd)
                {
                    bool targetIsAbove = currentPosition[0] > parkingPositon[0];
                    currentPosition[0] += targetIsAbove ? -2 : 2;
                    goingLeft = !goingLeft;
                    distance += 2;
                }
            }
            return distance;
        }

        private static bool AtSpot(int[] currentPosition, int[] parkingPositon)
        {
            bool sameCol = currentPosition[1] == parkingPositon[1];

            bool isOver = currentPosition[0] == parkingPositon[0] - 1;
            bool isUnder = currentPosition[0] == parkingPositon[0] + 1;

            bool nextTo = isOver || isUnder;

            return sameCol && nextTo;
        }

        private static int[] GetParkingPosition(string parkingSpot)
        {
            char letter = parkingSpot[0];
            int row = (int.Parse(parkingSpot.Substring(1)) - 1) * 2;
            int col = letter - 'A' + 1;

            return new int[] { row, col };
        }

        private static bool[][] CreateParking()
        {
            int[] coordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int actualRows = coordinates[0] * 2 - 1;
            int actualCols = coordinates[1] + 2;

            bool[][] parking = new bool[actualCols][];

            for (int row = 0; row < parking.Length; row++)
            {
                parking[row] = new bool[actualCols];
            }

            return parking;
        }
    }
}
