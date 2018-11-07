using Military.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Soldiers
{
    public class Repair : IRepair
    {
        private string partName;
        private int hoursWorked;

        public Repair(string partName, int hoursWorked)
        {
            this.PartName = partName;
            this.HoursWorked = hoursWorked;
        }

        public string PartName { get => partName; set => partName = value; }
        public int HoursWorked { get => hoursWorked; set => hoursWorked = value; }

        public override string ToString()
        {
            return $"Part Name: {this.partName} Hours Worked: {this.HoursWorked}";
        }
    }
}
