namespace StorageMester.Tests.Structure
{
    using NUnit.Framework;
    using StorageMaster.Entities.Storage;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    class StorageMasterStructureStorageTests
    {
        [Test]
        public void CheckIfAllPropertiesOfStorageExists()
        {
            Type type = typeof(Storage);

            string[] actualProperties = type
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(p => p.Name).ToArray();

            string[] expectedProperties = new string[6]
            {
                "Name",
                "Capacity",
                "GarageSlots",
                "IsFull",
                "Garage",
                "Products"
            };

            Assert.That(expectedProperties, Is.EquivalentTo(actualProperties));
        }

        [Test]
        public void CheckIfAllFieldsOfStorageExists()
        {
            Type type = typeof(Storage);

            string[] actualFields = type
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                .Select(f => f.Name).ToArray();

            string[] expectedFields = new string[5]
            {
                "garage",
                "products",
                "<Name>k__BackingField",
                "<Capacity>k__BackingField",
                "<GarageSlots>k__BackingField"

            };

            Assert.That(expectedFields, Is.EquivalentTo(actualFields));
        }

        [Test]
        public void CheckIfAllStorageMethodsExist()
        {
            Type type = typeof(Storage);

            string[] actualMethods = type
                .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Select(m => m.Name)
                .ToArray();

            string[] expected = new string[17]
            {
                "get_Name",
                "get_Capacity",
                "get_GarageSlots",
                "get_IsFull",
                "get_Garage",
                "get_Products",
                "GetVehicle",
                "SendVehicleTo",
                "UnloadVehicle",
                "InitializeGarage",
                "AddVehicle",
                "ToString",
                "Equals",
                "GetHashCode",
                "GetType",
                "Finalize",
                "MemberwiseClone"
            };

            Assert.That(expected, Is.EquivalentTo(actualMethods));
        }

        [Test]
        public void CheckIfAllStorageConstructorsWork()
        {
            Type automatedWarehouseType = typeof(AutomatedWarehouse);
            Type distributionCenterType = typeof(DistributionCenter);
            Type warehouseType = typeof(Warehouse);

            Type[] types = { automatedWarehouseType, distributionCenterType, warehouseType };

            BindingFlags bf = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

            foreach (var type in types)
            {
                Assert.That(type.GetConstructors(bf).First().IsPublic, $"{type.Name} constructor is not public");
            }
        }
    }
}
