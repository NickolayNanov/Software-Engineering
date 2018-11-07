using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public interface IVehicle
    {
        double FuelQuantity { get; set; }
        double FuelConsumptionPerKm { get; set; }
        double Tank { get; set; }
        bool IsVehicleEmpty { get; set; }
        void Drive(double distance);
        void Refuel(double litters);
    }
}
