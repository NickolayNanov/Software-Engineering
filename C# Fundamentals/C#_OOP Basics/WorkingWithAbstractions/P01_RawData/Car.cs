using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Car
    {
        private string model;
        private int engineSpeed;
        private int enginePower;
        private int cargoWeight;
        private string cargoType;
        private Dictionary<double, int> tires;

        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
        {
            this.Model = model;
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
            this.CargoWeight = cargoWeight;
            this.CargoType = cargoType;
            this.Tires = new Dictionary<double, int>();
            this.Tires.Add(tire1Pressure, tire1Age);
            this.Tires.Add(tire2Pressure, tire2Age);
            this.Tires.Add(tire3Pressure, tire3Age);
            this.Tires.Add(tire4Pressure, tire4Age);
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        
        public int EngineSpeed
        {
            get { return engineSpeed; }
            set { engineSpeed = value; }
        }
        
        public int EnginePower
        {
            get { return enginePower; }
            set { enginePower = value; }
        }
        
        public int CargoWeight
        {
            get { return cargoWeight; }
            set { cargoWeight = value; }
        }
        
        public string CargoType
        {
            get { return cargoType; }
            set { cargoType = value; }
        }       

        public Dictionary<double, int> Tires
        {
            get { return tires; }
            set { tires = value; }
        }

    }
}
