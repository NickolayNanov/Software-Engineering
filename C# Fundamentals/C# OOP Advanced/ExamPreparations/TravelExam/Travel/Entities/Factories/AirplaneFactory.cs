namespace Travel.Entities.Factories
{
    using Airplanes.Contracts;
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class AirplaneFactory : IAirplaneFactory
    {
        public IAirplane CreateAirplane(string typeName)
        {
            Type type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == typeName);

            IAirplane plane = (IAirplane)Activator.CreateInstance(type);

            return plane;
        }
    }
}