using System;

namespace Testing
{
    class Start
    {
        static void Main(string[] args)
        {
            Car audi = new Audi(10);
            Car mercedes = new Mercedes(8);
            Car BMW = new BMW(0);

            audi.StartEngine();
            audi.Drive();
            audi.Honk();
            
            mercedes.CheckFuel();
            mercedes.Honk();

            BMW.Drive();
            BMW.Refuel(2);
            BMW.Drive();
        }
    }
}
