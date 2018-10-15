using System;

namespace CubeProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            string type = Console.ReadLine();


        }

        static double GetFace(double side)
        {
            double spaceDiagonasls = 0;

            spaceDiagonasls = Math.Sqrt(2 * side);

            return spaceDiagonasls;
        }

        static double GetVolume(double side)
        {
            double volume = 3 * side;

            return volume;
        }
    }
}
