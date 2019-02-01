namespace Travel.Entities.Airplanes
{
    using Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Travel.Entities.Airplanes.Contracts;

    public abstract class Airplane : IAirplane
    {
        private List<IBag> baggageCompartment;
        private List<IPassenger> passengers;

        protected Airplane(int seats, int baggageCompartments)
        {
            this.Seats = seats;
            this.BaggageCompartments = baggageCompartments;


            this.passengers = new List<IPassenger>();
            this.baggageCompartment = new List<IBag>();
        }

        public int Seats { get; private set; }

        public int BaggageCompartments { get; private set; }

        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.AsReadOnly();

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();

        public bool IsOverbooked => this.Passengers.Count > this.Seats;

        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public IPassenger RemovePassenger(int seatIndex)
        {
            IPassenger passenger = this.passengers[seatIndex];

            this.passengers.RemoveAt(seatIndex);
            return passenger;
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            IBag[] passengerBags = this.baggageCompartment
                .Where(b => b.Owner == passenger)
                .ToArray();

            List<IBag> bagsToEject = new List<IBag>();

            foreach (var bag in passengerBags)
            {
                bagsToEject.Add(bag);
                this.baggageCompartment.Remove(bag);
            }

            return bagsToEject;
        }

        public void LoadBag(IBag bag)
        {
            bool isBaggageCompartmentFull = this.BaggageCompartment.Count > this.BaggageCompartments;

            if (isBaggageCompartmentFull)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().ToString()}!");
            }

            this.baggageCompartment.Add(bag);
        }
    }
}