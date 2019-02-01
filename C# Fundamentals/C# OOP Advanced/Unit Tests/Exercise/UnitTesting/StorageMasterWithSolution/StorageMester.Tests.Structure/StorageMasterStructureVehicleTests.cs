namespace StorageMester.Tests.Structure
{
    using NUnit.Framework;
    using StorageMaster.Entities.Storage;
    using StorageMaster.Entities.Vehicles;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class StorageMasterStructureVehicleTests
    {
        [Test]
        public void CheckIfAllPropertiesOfVehicleExists()
        {
            Type type = typeof(Vehicle);

            string[] actualProperties = type
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(p => p.Name).ToArray();

            string[] expectedProperties = new string[4]
            {
                "Capacity",
                "Trunk",
                "IsFull",
                "IsEmpty"
            };

            Assert.That(expectedProperties, Is.EquivalentTo(actualProperties));
        }

        [Test]
        public void CheckIfAllFieldsOfVehicleExists()
        {
            Type type = typeof(Vehicle);

            string[] actualFields = type
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                .Select(f => f.Name).ToArray();

            string[] expectedFields = new string[2]
            {
                "trunk",
                "<Capacity>k__BackingField",
            };

            Assert.That(expectedFields, Is.EquivalentTo(actualFields));
        }

        [Test]
        public void CheckVehicleConstructorIsPrivate()
        {
            Type type = typeof(Vehicle);

            var constructor = type
                .GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Instance)
                .First();

            Assert.That(constructor.IsFamily);
        }

        [Test]
        public void CheckIfAllVehiclesConstructorsWork()
        {
            Type semiType = typeof(Semi);
            Type truckType = typeof(Truck);
            Type vanType = typeof(Van);

            Type[] types = { semiType, truckType, vanType };

            BindingFlags bf = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

            foreach (var type in types)
            {
                var constructor = type.GetConstructors(bf).First();
                Assert.That(constructor.IsPublic, $"{type.Name} constructor is not public");
            }
        }

        [Test]
        public void CheckIfAllVehicleMethoodsExist()
        {
            Type type = typeof(Vehicle);

            string[] actualMethods = type
                .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Select(m => m.Name)
                .ToArray();

            string[] expected = new string[12]
            {
                "get_Capacity",
                "get_Trunk",
                "get_IsFull",
                "get_IsEmpty",
                "LoadProduct",
                "Unload",
                "ToString",
                "Equals",
                "GetHashCode",
                "GetType",
                "Finalize",
                "MemberwiseClone"
            };

            Assert.That(expected, Is.EquivalentTo(actualMethods));
        }    

    }
}
