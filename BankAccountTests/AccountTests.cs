using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;

namespace BankAccountTests
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void AccountNumber_ValidFormat_ShouldAccept()
        {
            // Arrange & Act
            var account = new Account { AccountNumber = "1234-ABCDE" };

            // Assert
            Assert.AreEqual("1234-ABCDE", account.AccountNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AccountNumber_InvalidFormat_ShouldThrowException()
        {
            // Arrange & Act
            _ = new Account { AccountNumber = "123-ABCDE" };

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AccountNumber_InvalidCharacters_ShouldThrowException()
        {
            // Arrange & Act
            _ = new Account { AccountNumber = "1234-ABC12" };

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        public void Deposit_PositiveAmount_ShouldIncreaseBalance()
        {
            // Arrange
            var account = new Account { AccountNumber = "1234-ABCDE" };

            // Act
            decimal newBalance = account.Deposit(100.00m);

            // Assert
            Assert.AreEqual(100.00m, account.Balance);
            Assert.AreEqual(100.00m, newBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Deposit_ZeroAmount_ShouldThrowException()
        {
            // Arrange
            var account = new Account { AccountNumber = "1234-ABCDE" };

            // Act
            account.Deposit(0);

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Deposit_NegativeAmount_ShouldThrowException()
        {
            // Arrange
            var account = new Account { AccountNumber = "1234-ABCDE" };

            // Act
            account.Deposit(-50.00m);

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        public void Withdraw_ValidAmount_ShouldDecreaseBalance()
        {
            // Arrange
            var account = new Account { AccountNumber = "1234-ABCDE" };
            account.Deposit(100.00m);

            // Act
            decimal newBalance = account.Withdraw(50.00m);

            // Assert
            Assert.AreEqual(50.00m, account.Balance);
            Assert.AreEqual(50.00m, newBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Withdraw_ZeroAmount_ShouldThrowException()
        {
            // Arrange
            var account = new Account { AccountNumber = "1234-ABCDE" };

            // Act
            account.Withdraw(0);

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Withdraw_NegativeAmount_ShouldThrowException()
        {
            // Arrange
            var account = new Account { AccountNumber = "1234-ABCDE" };

            // Act
            account.Withdraw(-50.00m);

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Withdraw_InsufficientFunds_ShouldThrowException()
        {
            // Arrange
            var account = new Account { AccountNumber = "1234-ABCDE" };
            account.Deposit(50.00m);

            // Act
            account.Withdraw(100.00m);

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        public void AccountNumber_CaseInsensitive_ShouldAccept()
        {
            // Arrange & Act
            var account = new Account { AccountNumber = "1234-abcde" };

            // Assert
            Assert.AreEqual("1234-abcde", account.AccountNumber);
        }
    }
}