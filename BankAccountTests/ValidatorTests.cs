using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccount.Tests;

[TestClass()]
public class ValidatorTests
{
    [TestMethod()]
    public void IsWithinRange_MinInclusiveBound_ReturnsTrue()
    {
        // Arrange
        Validator validator = new();
        double minBoundary = 10;
        double maxBoundary = 100;
        double valueToTest = 10;

        // Act
        bool result = validator.IsWithinRange(valueToTest, minBoundary, maxBoundary);

        // Assert
        Assert.IsTrue(result);
    }
    [TestMethod]
    public void IsWithinRange_MaxInclusiveBound_ReturnsTrue()
    {
                // Arrange
        Validator validator = new();
        double minBoundary = 10;
        double maxBoundary = 100;
        double valueToTest = 100;

        // Act
        bool result = validator.IsWithinRange(valueToTest, minBoundary, maxBoundary);

        // Assert
        Assert.IsTrue(result);
    }
    [TestMethod]
    public void IsWithinRange_ValueWithinBounds_ReturnsTrue()
    {
        // Arrange
        Validator validator = new();
        double minBoundary = 10;
        double maxBoundary = 100;
        double valueToTest = 50;

        // Act
        bool result = validator.IsWithinRange(valueToTest, minBoundary, maxBoundary);

        // Assert
        Assert.IsTrue(result);
    }
    [TestMethod]
    public void IsWithinRange_ValueBelowMinBound_ReturnsFalse()
    {
        // Arrange
        Validator validator = new();
        double minBoundary = 10;
        double maxBoundary = 100;
        double valueToTest = 5;
        // Act
        bool result = validator.IsWithinRange(valueToTest, minBoundary, maxBoundary);
        // Assert
        Assert.IsFalse(result);
    }
    [TestMethod]
    public void IsWithinRange_ValueAboveMaxBound_ReturnsFalse()
    {
        // Arrange
        Validator validator = new();
        double minBoundary = 10;
        double maxBoundary = 100;
        double valueToTest = 150;
        // Act
        bool result = validator.IsWithinRange(valueToTest, minBoundary, maxBoundary);
        // Assert
        Assert.IsFalse(result);
    }
    [TestMethod]
    public void IsWithinRange_MinBoundaryGreaterThanMaxBoundary_ThrowsArgumentException()
    {
        // Arrange
        Validator validator = new();
        double minBoundary = 10;
        double maxBoundary = 5;
        double valueToTest = 7;

        // Assert => Act
        Assert.ThrowsException<ArgumentException>(() =>
            validator.IsWithinRange(valueToTest, minBoundary, maxBoundary));
    }
}