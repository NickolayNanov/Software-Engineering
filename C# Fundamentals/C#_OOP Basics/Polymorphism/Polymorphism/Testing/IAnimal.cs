using System;
using System.Collections.Generic;
using System.Text;

namespace Testing
{
    public interface IAnimal
    {
        string Kind { get; set; }

        void Climb();

        void Walk(); 
    }
}
