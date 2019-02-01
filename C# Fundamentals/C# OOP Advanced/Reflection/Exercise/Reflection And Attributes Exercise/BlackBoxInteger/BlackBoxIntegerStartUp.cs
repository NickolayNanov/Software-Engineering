namespace BlackBoxInteger
{
    using System;

    public class BlackBoxIntegerStartUp
    {
        public static void Main(string[] args)
        {
            BlackBoxIntegerTests bbi = new BlackBoxIntegerTests();

            Console.WriteLine(bbi.Run());
        }
    }
}