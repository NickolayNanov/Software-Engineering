using System;
using System.Collections.Generic;
using System.Text;

namespace Testing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Pesho pesho = new Pesho();
            pesho.Nickname = "Pesho";
            pesho.Age = 5;
            Console.WriteLine(pesho);
            pesho.Grow();
            Console.WriteLine(pesho);
        }
    }
}
