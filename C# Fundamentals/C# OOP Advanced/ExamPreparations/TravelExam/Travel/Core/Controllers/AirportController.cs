namespace Travel.Core.Controllers
{
    using Contracts;
    using Entities;
    using Entities.Contracts;
    using Entities.Factories;
    using Entities.Factories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Travel.Entities.Airplanes.Contracts;
    using Travel.Entities.Items.Contracts;

    public class AirportController : IAirportController
    {
        private const int BagValueConfiscationThreshold = 3000;

        private IAirport airport;

        private IAirplaneFactory airplaneFactory;
        private IItemFactory itemFactory;

        public AirportController(IAirport airport)
        {
            this.airport = airport;
            this.airplaneFactory = new AirplaneFactory();
            this.itemFactory = new ItemFactory();
        }

        //100/100
        public string RegisterPassenger(string username)
        {
            bool CheckIfPassengerExists = this.airport.GetPassenger(username) != null;

            if (CheckIfPassengerExists)
            {
                throw new InvalidOperationException($"Passenger {username} already registered!");
            }

            IPassenger passenger = new Passenger(username);

            this.airport.AddPassenger(passenger);

            return $"Registered {passenger.Username}";
        }
        //100/100
        public string RegisterTrip(string source, string destination, string planeType)
        {
            IAirplane airplane = this.airplaneFactory.CreateAirplane(planeType);

            ITrip trip = new Trip(source, destination, airplane);

            this.airport.AddTrip(trip);

            return $"Registered trip {trip.Id}";
        }
        //100/100
        public string RegisterBag(string username, IEnumerable<string> bagItems)
        {
            IPassenger passenger = this.airport.GetPassenger(username);

            IItem[] items = bagItems.Select(i => this.itemFactory.CreateItem(i)).ToArray();
            IBag bag = new Bag(passenger, items);

            passenger.Bags.Add(bag);

            return $"Registered bag with {string.Join(", ", bagItems)} for {username}";
        }
        //100/100
        public string CheckIn(string username, string tripId, IEnumerable<int> bagIndices)
        {
            IPassenger passenger = this.airport.GetPassenger(username);
            ITrip trip = this.airport.GetTrip(tripId);

            var checkedIn = this.airport.Trips.Any(t => t.Airplane.Passengers.Any(p => p == passenger));
            if (checkedIn)
            {
                throw new InvalidOperationException($"{username} is already checked in!");
            }

            int confiscatedBags = CheckInBags(passenger, bagIndices);
            trip.Airplane.AddPassenger(passenger);

            return $"Checked in {passenger.Username} with {bagIndices.Count() - confiscatedBags}/{bagIndices.Count()} checked in bags";
        }
        
        private int CheckInBags(IPassenger passenger, IEnumerable<int> bagsToCheckIn)
        {
            IList<IBag> bags = passenger.Bags;

            int confiscatedBagCount = 0;
            foreach (var i in bagsToCheckIn)
            {
                IBag currentBag = bags[i];
                bags.Remove(currentBag);

                if (ShouldConfiscate(currentBag))
                {
                    airport.AddConfiscatedBag(currentBag);
                    confiscatedBagCount++;
                }
                else
                {
                    this.airport.AddCheckedBag(currentBag);
                }
            }

            return confiscatedBagCount;
        }

        private static bool ShouldConfiscate(IBag bag)
        {
            var luggageValue = 0;

            IItem[] items = bag.Items.ToArray();

            for (int i = 0; i <= bag.Items.Count - 1; i++)
            {
                luggageValue += items[i].Value;
            }

            bool shouldConfiscate = luggageValue > BagValueConfiscationThreshold;
            return shouldConfiscate;
        }
    }
}