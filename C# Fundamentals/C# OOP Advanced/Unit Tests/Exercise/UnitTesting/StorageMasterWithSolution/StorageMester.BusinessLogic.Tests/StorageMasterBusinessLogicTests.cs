namespace StorageMester.BusinessLogic.Tests
{
    using NUnit.Framework;
    using StorageMaster.Core;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Storage;
    using StorageMaster.Entities.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class StorageMasterBusinessLogicTests
    {  // UnloadVehicle, GetStorage, GetSummary

        private const string ProductsPoolName = "productsPool";
        private const string StorageRegistryName = "storageRegistry";
        private const string CurrentVehicleName = "currentVehicle";

        [Test]
        public void CheckIfAddsCorrectly()
        {
            Storagemaster storageMaster = new Storagemaster();

            var field = typeof(Storagemaster)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.Name == ProductsPoolName);

            Product product = (Product)Activator.CreateInstance(typeof(Ram), new object[] { 13.5 });

            storageMaster.AddProduct("Ram", 13.5);
            Dictionary<string, Stack<Product>> pool = (Dictionary<string, Stack<Product>>)field.GetValue(storageMaster);

            Assert.That(pool["Ram"].Any(x => x.Price == 13.5));
        }

        [Test]
        public void CheckIfRegistersCorrectly()
        {
            Storagemaster storageMaster = new Storagemaster();

            var field = typeof(Storagemaster)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.Name == StorageRegistryName);

            storageMaster.RegisterStorage("Warehouse", "warehouse");

            Dictionary<string, Storage> storageRegistry = (Dictionary<string, Storage>)field.GetValue(storageMaster);

            Assert.That(storageRegistry, Does.ContainKey("warehouse"));
        }

        [Test]
        public void SelectVehicleIfWorkingProperly()
        {
            Storagemaster storageMaster = new Storagemaster();

            var field = typeof(Storagemaster)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.Name == StorageRegistryName);

            storageMaster.RegisterStorage("Warehouse", "warehouse");
            Dictionary<string, Storage> storageRegistry = (Dictionary<string, Storage>)field.GetValue(storageMaster);

            string actual = storageMaster.SelectVehicle("warehouse", 1);
            string expected = $"Selected Semi";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckIfLoadVehicleWorksCorrectly()
        {
            Storagemaster storageMaster = new Storagemaster();
            storageMaster.RegisterStorage("Warehouse", "storage");
            storageMaster.SelectVehicle("storage", 1);
            storageMaster.AddProduct("Gpu", 12);
            storageMaster.AddProduct("HardDrive", 120);

            List<string> productsToLoad = new List<string>() {"Gpu", "HardDrive"};

            storageMaster.LoadVehicle(productsToLoad);

            FieldInfo vehicleField = typeof(Storagemaster)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.Name == CurrentVehicleName);

            Vehicle vehicle = (Vehicle)vehicleField.GetValue(storageMaster);

            Assert.AreEqual(2, vehicle.Trunk.Count);
        }

        [Test]
        public void CheckIfLoadVehicleThrowsExpection()
        {
            Storagemaster storageMaster = new Storagemaster();
            storageMaster.RegisterStorage("Warehouse", "storage");
            storageMaster.SelectVehicle("storage", 1);           

            List<string> productsToLoad = new List<string>() { "Gpu", "HardDrive" };

            Assert.Throws<InvalidOperationException>(() => storageMaster.LoadVehicle(productsToLoad));
        }

        [Test]
        public void CheckIfSendVehicleThrowsExceptionWithInvalidSourse()
        {
            Storagemaster storageMaster = new Storagemaster();

            Assert.Throws<InvalidOperationException>(() => storageMaster.SendVehicleTo("asd", 1, "dsa"));
        }

        [Test]
        public void CheckIfSendVehicleThrowsExceptionWithInvalidReciver()
        {
            Storagemaster storageMaster = new Storagemaster();
            storageMaster.RegisterStorage("Warehouse", "house");

            Assert.Throws<InvalidOperationException>(() => storageMaster.SendVehicleTo("house", 1, "dsa"));
        }

        [Test]
        public void CheckIfSendVehicle()
        {
            Storagemaster storageMaster = new Storagemaster();
            storageMaster.RegisterStorage("Warehouse", "source");
            storageMaster.RegisterStorage("Warehouse", "receiver");

            string actualResult = storageMaster.SendVehicleTo("source", 1, "receiver");
            string expectedResult = $"Sent Semi to receiver (slot 3)";

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}