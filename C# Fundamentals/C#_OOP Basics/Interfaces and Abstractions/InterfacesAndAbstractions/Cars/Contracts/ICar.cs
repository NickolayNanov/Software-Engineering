using System;

namespace Cars
{
    public interface ICar
    {
        string Model { get; set; }
        string Colour { get; set; }
        void StartEngine();
        void StopEngine();
    }
}
