using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : IFerari
    {
        private const string model = "488-Spider";
        private string driver;

        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Driver
        {
            get => this.driver;
            set => this.driver = value;
        }

        public string PushBreaks()
        {
            return "Brakes!";
        }

        public string PushGasPedal()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{model}/{PushBreaks()}/{PushGasPedal()}/{this.Driver}";
        }
    }
}
