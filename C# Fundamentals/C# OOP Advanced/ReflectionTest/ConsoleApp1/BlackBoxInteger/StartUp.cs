namespace BlackBoxInteger
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            BlackBoxIntegerTests bbi = new BlackBoxIntegerTests();
            Console.WriteLine(bbi.Run());
        }
    }
}
