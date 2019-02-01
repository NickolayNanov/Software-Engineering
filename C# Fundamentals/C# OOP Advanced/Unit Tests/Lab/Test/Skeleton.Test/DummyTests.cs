using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(5);

            int expected = 5;
            int actualResult = dummy.Health;

            Assert.AreEqual(expected, actualResult, "Axe does not lose durability after attack.");
        }

        [Test]
        public void DummyThrowsAnExceptionIfAttacked()
        {
            Dummy dummy = new Dummy(0, 3);
            
            Assert.Throws<InvalidOperationException>(() =>       
                dummy.TakeAttack(20));
        }

        [Test]
        public void DeadDummyCanGiveExp()
        {
            Dummy dummy = new Dummy(0, 123);

            int actualResult = dummy.GiveExperience();
            int expetedResult = 123;

            Assert.AreEqual(actualResult, expetedResult);
        }

        [Test]
        public void AliveDummyCantGiveExp()
        {
            Dummy dummy = new Dummy(10, 123);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }

    }
}
