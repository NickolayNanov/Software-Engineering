using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;

        public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        
        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }
        
        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        private List<Tire> tires;

        public List<Tire> Tires
        {
            get { return tires; }
            set { tires = value; }
        }

    }
}
