namespace Skeleton.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void TestIfWeaponLosesDurabilityAfterAttack()
        {
            //Arrange
            Dummy dummy = new Dummy(10, 10);
            Axe axe = new Axe(10, 10);

            //Act
            axe.Attack(dummy);
            int actualResult = axe.DurabilityPoints;
            var expected = 9;

            //Assert
            Assert.AreEqual(actualResult, expected);
        }

        [Test]
        public void TestAttackingWithBrokenWeapon()
        {
            //Arrange
            Dummy dummy = new Dummy(10, 10);
            Axe axe = new Axe(10, 0);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });

            Assert.Throws(typeof(InvalidOperationException), () => axe.Attack(dummy));
        }
    }
}
