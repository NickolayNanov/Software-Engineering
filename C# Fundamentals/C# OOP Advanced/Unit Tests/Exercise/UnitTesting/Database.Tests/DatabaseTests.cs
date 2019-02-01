namespace Tests
{
    using DataBase;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class DatabaseTests
    {
        private const string NameOfArray = "data";
        private const string NameOfIndex = "currentIndex";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmptyCostructorShouldInitializeInItData()
        {
            //Arrange
            DataBase db = new DataBase();

            FieldInfo field = typeof(DataBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.Name == NameOfArray);

            //Act
            int actual = 16;
            int[] fieldAsArray = (int[])(field.GetValue(db));
            int expected = fieldAsArray.Length;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckIfAddsCorrectly()
        {
            //Arrange
            DataBase db = new DataBase();

            //Act
            FieldInfo field = typeof(DataBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.Name == NameOfArray);

            db.Add(3);

            int[] dataAsArray = (int[])(field.GetValue(db));

            //Assert
            Assert.That(dataAsArray, Does.Contain(3));
        }

        [Test]
        public void CheckIfConstructorThrowsExceptionIfGivenMoreThanSixteenElements()
        {
            Assert.Throws<InvalidOperationException>(() =>
            new DataBase(new int[17]));
        }

        [Test]
        public void CheckIfIndexChangesProperlyWhenAdding()
        {
            DataBase db = new DataBase();

            FieldInfo reflectedIndex = typeof(DataBase)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == NameOfIndex);

            db.Add(1);

            int actual = (int)(reflectedIndex.GetValue(db));
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckIfIndexEqualsMinusOneWhenDbInit()
        {
            DataBase db = new DataBase();

            FieldInfo reflectedIndex = typeof(DataBase)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == NameOfIndex);

            int actual = (int)(reflectedIndex.GetValue(db));
            int expected = -1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckIfIndexChangesProperlyWhenRemoving()
        {
            DataBase db = new DataBase();

            FieldInfo reflectedIndex = typeof(DataBase)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == NameOfIndex);

            db.Add(1);
            db.Add(2);
            db.Add(3);

            db.Remove();

            int actual = (int)(reflectedIndex.GetValue(db));
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckIfThrowsExceptionWhenAddNewElementAndCapacityIsMaxed()
        {
            DataBase db = new DataBase(new int[16]);

            Assert.Throws<InvalidOperationException>(() => db.Add(3));
        }

        [Test]
        public void CheckIfThrowsExceptionWhenTryToRemoveFromAnEmptyArray()
        {
            DataBase db = new DataBase();

            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void CheckIfRemoveCorrectlyElementFromCollection()
        {
            //Arrange
            DataBase db = new DataBase(new int[] { 1, 2, 3 });

            FieldInfo dataField = typeof(DataBase)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == NameOfArray);

            FieldInfo indexField = typeof(DataBase)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == NameOfIndex);

            //Act
            db.Remove();

            int[] dataAsArray = (int[])(dataField.GetValue(db));

            dataAsArray = dataAsArray
                .Take((int)indexField.GetValue(db) + 1)
                .ToArray();

            //Assert

            int actual = dataAsArray.Length;
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckIfCurrentIndexDecreasesProperlyWhenItemIsRemoved()
        {
            //Arrange
            DataBase db = new DataBase(new int[] { 1 });

            FieldInfo reflectedIndex = typeof(DataBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.Name == NameOfIndex);

            //Act
            db.Remove();

            //Assert
            int actual = (int)(reflectedIndex.GetValue(db));
            int expected = -1;

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void CheckIfFetchReturnsProperCountOfElements()
        {
            DataBase db = new DataBase(new int[] { 1, 2, 3 });

            FieldInfo reflectedData = typeof(DataBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.Name == NameOfArray);


            int[] array = new int[] { 1, 2, 3 };

            int[] dbArray = db.Fetch();

            int actual = dbArray.Length;
            int expected = array.Length;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckIfElementsFromFetchAreTheReadOnes()
        {
            int[] array = new int[3] { 1, 2, 3 };

            DataBase db = new DataBase(array);

            int[] actualArray = db.Fetch();
            int[] expectedArray = array;

            Assert.AreEqual(expectedArray, actualArray);
        }
}
}