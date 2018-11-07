using AnimalFarm.Animals;
using AnimalFarm.Core;
using System;

namespace AnimalFarm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
