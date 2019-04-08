namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class BaseVehicleTests
    {
        [Test]
        public void CheckIfConstructorIsProtected()
        {
            var type = typeof(BaseVehicle).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).First();

            Assert.That(type.IsFamily, Is.True);
        }

        [Test]
        public void CheckIfAllPropertiesExists()
        {
            string[] expected =
            {
                "Model",
                "Weight",
                "Price",
                "Attack",
                "Defense",
                "HitPoints",
                "TotalWeight",
                "TotalPrice",
                "TotalAttack",
                "TotalDefense",
                "TotalHitPoints",
                "Parts"
            };

            var ActualProperties = typeof(BaseVehicle).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            string[] actual = ActualProperties.Select(p => p.Name).ToArray();

            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void CheckIfAllFieldsArePrivate()
        {
            var properties = typeof(BaseVehicle).GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var prop in properties)
            {
                Assert.That(prop.GetType().IsNotPublic);
            }
        }

        [Test]
        public void CheckIfValueIsSetCorectlly()
        {
            var vehicle = new Revenger("Model", 1.3, (decimal)4.1, 4, 5, 6, new VehicleAssembler());

            var properties = vehicle.GetType().GetProperties();

            Assert.That(vehicle.Model == "Model", Is.True);
            Assert.That(vehicle.Weight == 1.3, Is.True);
            Assert.That(vehicle.Price == (decimal)4.1, Is.True);
            Assert.That(vehicle.Attack == 4, Is.True);
            Assert.That(vehicle.Defense == 5, Is.True);
            Assert.That(vehicle.HitPoints == 6, Is.True);
        }

        [Test]
        public void CheckIfPropertyThrowException()
        {
            IVehicle vehicle;

            Assert.That(() => vehicle = new Revenger(null, 1, 3, 1, 3, 4, new VehicleAssembler()),
    Throws.ArgumentException
      .With.Message.EqualTo("Model cannot be null or white space!"));

            Assert.That(() => vehicle = new Revenger("asd", -1, 3, 1, 3, 4, new VehicleAssembler()),
    Throws.ArgumentException
      .With.Message.EqualTo("Weight cannot be less or equal to zero!"));

            Assert.That(() => vehicle = new Revenger("asd", 3, -1, 1, 3, 4, new VehicleAssembler()),
    Throws.ArgumentException
      .With.Message.EqualTo("Price cannot be less or equal to zero!"));

            Assert.That(() => vehicle = new Revenger("asd", 3, 3, -3, 3, 4, new VehicleAssembler()),
    Throws.ArgumentException
      .With.Message.EqualTo("Attack cannot be less than zero!"));

            Assert.That(() => vehicle = new Revenger("asd", 3, 3, 3, -3, 4, new VehicleAssembler()),
    Throws.ArgumentException
      .With.Message.EqualTo("Defense cannot be less than zero!"));

            Assert.That(() => vehicle = new Revenger("asd", 3, 3, 3, 3, -4, new VehicleAssembler()),
    Throws.ArgumentException
      .With.Message.EqualTo("HitPoints cannot be less than zero!"));

        }

        [Test]
        public void CheckToString()
        {
            IVehicle vehicle = new Revenger("asd", 1, 3, 1, 3, 4, new VehicleAssembler());
            var arsenal = new ArsenalPart("asd", 12, 3, 4);
            var endurance = new EndurancePart("asd", 3, 3, 4);
            var shell = new ShellPart("asd", 3, 3, 4);

            vehicle.AddEndurancePart(endurance);
            vehicle.AddArsenalPart(arsenal);
            vehicle.AddShellPart(shell);

            Assert.That(vehicle.Parts, Has.Member(arsenal));
            Assert.That(vehicle.Parts, Has.Member(endurance));
            Assert.That(vehicle.Parts, Has.Member(shell));
        }

        [Test]
        public void ASD()
        {
            IVehicle vehicle = new Revenger("asd", 1, 3, 1, 3, 4, new VehicleAssembler());
            long attack = vehicle.TotalAttack;
            long defence = vehicle.TotalDefense;
            double weight = vehicle.TotalWeight;
            long hitpoints = vehicle.TotalHitPoints;
            
            Assert.AreEqual(attack, 1);
            Assert.AreEqual(defence, 3);
            Assert.AreEqual(weight, 1);
            Assert.AreEqual(hitpoints, 4);
            ;
        }
    }
}