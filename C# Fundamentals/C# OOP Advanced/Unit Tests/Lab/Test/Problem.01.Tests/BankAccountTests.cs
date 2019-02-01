using NUnit.Framework;
using System;
using Testing;

namespace Problem._01.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void ValidateDepositAmount()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount();
                       
            //Act
            bankAccount.Deposit(20);
            bankAccount.Deposit(20);
            
            var expectedResult = 40;
            var actualResult = bankAccount.Amount;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
