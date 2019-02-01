// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
	using NUnit.Framework;
    using System;
    using Travel.Core.Controllers;
    using Travel.Core.Controllers.Contracts;
    using Travel.Entities;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Airplanes.Contracts;
    using Travel.Entities.Contracts;
    using Travel.Entities.Items;
    using Travel.Entities.Items.Contracts;

    [TestFixture]
    public class FlightControllerTests
    {
	    [Test]
	    public void Test1()
	    {
            IAirplane plane = new LightAirplane();

            IPassenger pasenger = new Passenger("Pesho2");

            plane.AddPassenger(new Passenger("Pesho1"));
            plane.AddPassenger(pasenger);
            plane.AddPassenger(new Passenger("Pesho3"));
            plane.AddPassenger(new Passenger("Pesho4"));
            plane.AddPassenger(new Passenger("Pesho5"));
            plane.AddPassenger(new Passenger("Pesho6"));

            ITrip trip = new Trip("Sofia", "London", plane);

            IAirport airport = new Airport();
            airport.AddTrip(trip);

            IFlightController flightController = new FlightController(airport);

            IBag bag = new Bag(pasenger, new IItem[] { new Colombian() });
            pasenger.Bags.Add(bag);

            ITrip completedTrip = new Trip("London", "Sofia", new LightAirplane());
            completedTrip.Complete();

            airport.AddTrip(completedTrip);

            string actual = flightController.TakeOff();
            string expected = "SofiaLondon1:\r\nOverbooked! Ejected Pesho2\r\nConfiscated 1 bags ($50000)\r\nSuccessfully transported 5 passengers from Sofia to London.\r\nConfiscated bags: 1 (1 items) => $50000";

            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(trip.IsCompleted, Is.True);
        }
    }
}
