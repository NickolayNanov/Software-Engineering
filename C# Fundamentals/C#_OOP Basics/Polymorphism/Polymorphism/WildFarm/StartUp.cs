using System;
using WildFarm.Core;
using WildFarm.Models.Animals.AnimalModels.Feline;
using WildFarm.Models.Animals.AnimalModels.Mammals;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
