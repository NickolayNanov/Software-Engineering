namespace Tests
{
    using DataBaseExtended;
    using DataBaseExtended.Contracts;
    using DataBaseExtended.Models;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private const string ArrayName = "data";
        private static IPerson person = new Person(13, "Nick");

        [Test]
        public void CheckIfThrowsExceptionWhenThereIsAlreadyAPersonWithThatNameOrId()
        {
            DatabaseExtended db = new DatabaseExtended();

            db.Add(new Person(13, "Nick"));
            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(13, "Nick")));
        }

        [Test]
        public void CheckIfRemovesCorrectly()
        {
            DatabaseExtended db = new DatabaseExtended();

            FieldInfo reflectedData = typeof(DatabaseExtended)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.Name == ArrayName);

            IPerson person = new Person(13, "Nick");

            db.Add(person);
            db.Remove();

            IPerson[] people = (IPerson[])reflectedData.GetValue(db);

            Assert.That(people, !Does.Contain(person));
        }

        [Test]
        [TestCase("Nick")]
        public void CheckIfThereIsPersonWithSuchName(string name)
        {
            DatabaseExtended db = new DatabaseExtended();

            Assert.Throws<InvalidOperationException>(() => db.FindByUsername(name), "There is not such name");
        }

        [Test]
        [TestCase("Nick")]
        public void CheckIfContainsPersonWithSuchName(string name)
        {
            DatabaseExtended db = new DatabaseExtended();

            db.Add(new Person(12, "Todor"));
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername(name), "There is not such name");
        }

        [Test]
        public void CheckIfContainsPersonWithSuchName()
        {
            DatabaseExtended db = new DatabaseExtended();

            db.Add(new Person(12, "Todor"));
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername(null), "The name should not be null!");
        }

        [Test]
        [TestCase(3)]
        public void CheckIfContainsPersonWithSuchId(long id)
        {
            DatabaseExtended db = new DatabaseExtended();

            db.Add(new Person(12, "Todor"));
            Assert.Throws<InvalidOperationException>(() => db.FindById(id), "There is not people with such id!");
        }

        [Test]
        [TestCase(-3)]
        public void CheckIfPersonsIdIsNegative(long id)
        {
            DatabaseExtended db = new DatabaseExtended();

            db.Add(new Person(12, "Todor"));
            Assert.Throws<InvalidOperationException>(() => db.FindById(id), "There is not people with such id!");
        }
    }
}