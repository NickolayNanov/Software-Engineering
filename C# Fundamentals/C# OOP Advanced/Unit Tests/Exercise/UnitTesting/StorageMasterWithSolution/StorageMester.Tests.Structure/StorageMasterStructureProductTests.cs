using NUnit.Framework;
using StorageMaster.Entities.Products;
using System;
using System.Linq;
using System.Reflection;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    public class StorageMasterStructureProductTests
    {
        [Test]
        public void CheckIfAllPropertiesOfStorageExists()
        {
            Type type = typeof(Product);

            string[] actualProperties = type
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(p => p.Name).ToArray();

            string[] expectedProperties = new string[2]
            {
                "Price",
                "Weight"
            };

            Assert.That(expectedProperties, Is.EquivalentTo(actualProperties));
        }

        [Test]
        public void CheckIfAllFieldsOfStorageExists()
        {
            Type type = typeof(Product);

            string[] actualFields = type
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                .Select(f => f.Name).ToArray();

            string[] expectedFields = new string[2]
            {
                "price",
                "<Weight>k__BackingField"
            };

            Assert.That(expectedFields, Is.EquivalentTo(actualFields));
        }

        [Test]
        public void CheckIfAllStorageMethodsExist()
        {
            Type type = typeof(Product);

            string[] actualMethods = type
                .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Select(m => m.Name)
                .ToArray();

            string[] expected = new string[9]
            {
                "get_Price",
                "set_Price",
                "get_Weight",
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
            Type hardDriveType = typeof(HardDrive);
            Type gpuType = typeof(Gpu);
            Type ramType = typeof(Ram);
            Type SSDType = typeof(SolidStateDrive);

            Type[] types = { hardDriveType, gpuType, ramType, SSDType };

            BindingFlags bf = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

            foreach (var type in types)
            {
                Assert.That(type.GetConstructors(bf).First().IsPublic, $"{type.Name} constructor is not public");
            }
        }
    }
}
