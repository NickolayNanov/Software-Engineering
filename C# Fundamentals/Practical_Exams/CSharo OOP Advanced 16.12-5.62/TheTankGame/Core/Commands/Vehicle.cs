using System;
using System.Collections.Generic;
using System.Text;
using TheTankGame.Core.Contracts;
using TheTankGame.Entities.Vehicles.Contracts;
using TheTankGame.Entities.Vehicles.Factories;
using TheTankGame.Entities.Vehicles.Factories.Contracts;
using TheTankGame.Utils;

namespace TheTankGame.Core.Commands
{
    public class Vehicle : IExecutable
    {
        private readonly IVehicleFactory vehicleFactory;

        public Vehicle()
        {
            this.vehicleFactory = new VehicleFactory();
        }

        public string Execute(IList<string> arguments)
        {
            string vehicleType = arguments[0];
            string model = arguments[1];
            double weight = double.Parse(arguments[2]);
            decimal price = decimal.Parse(arguments[3]);
            int attack = int.Parse(arguments[4]);
            int defense = int.Parse(arguments[5]);
            int hitPoints = int.Parse(arguments[6]);

            IVehicle vehicle = this.vehicleFactory.CreateVehicle(vehicleType, model, weight, price, attack, defense, hitPoints); ;

            


            return string.Format(
                GlobalConstants.VehicleSuccessMessage,
                vehicleType,
                vehicle.Model);
        }
    }
}
