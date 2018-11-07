using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionFor1km = fuelConsumption;
            this.KilometersTravelled = 0;
        }

        private string model;
        private double fuelAmount;
        private double fuelConsumptionFor1km;
        private int kilometersTravelled;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }
        
        public double FuelConsumptionFor1km
        {
            get { return fuelConsumptionFor1km; }
            set { fuelConsumptionFor1km = value; }
        }

        public int KilometersTravelled
        {
            get { return kilometersTravelled; }
            set { kilometersTravelled = value; }
        }

        

    }
}
