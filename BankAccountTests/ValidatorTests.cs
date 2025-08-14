using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccount.Tests;

[TestClass()]
public class ValidatorTests
{
    [TestMethod()]
    [DataRow(10, 10)]
    [DataRow(5.001, 5.001)]
    [DataRow(1.000005, 1.000005)]
    [DataRow(-50.01, -50.01)]
    public void IsWithinRange_MinInclusiveBound_ReturnsTrue(double minBoundary, double valueToTest)
    {
        // Arrange
        Validator validator = new();
        double maxBoundary = minBoundary + 100;

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
    [DataRow(0, 0, 0)]
    [DataRow(-10, -10, -10)]
    [DataRow(50, 100, 75)]
    [DataRow(-200, -100, -150)]
    public void IsWithinRange_ValidRangeAndValue_ReturnsTrue(double minBoundary, double maxBoundary, double valueToTest)
    {
        // Arrange
        Validator validator = new();

        // Act
        bool result = validator.IsWithinRange(valueToTest, minBoundary, maxBoundary);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    [DataRow(0, 0, 1)]
    [DataRow(-10, -5, -4)]
    [DataRow(50, 100, 101)]
    [DataRow(-200, -100, -50)]
    public void IsWithinRange_ValueOutsideBounds_ReturnsFalse(double minBoundary, double maxBoundary, double valueToTest)
    {
        // Arrange
        Validator validator = new();

        // Act
        bool result = validator.IsWithinRange(valueToTest, minBoundary, maxBoundary);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    [DataRow(10, 5)]
    [DataRow(0, -1)]
    [DataRow(100, 50)]
    public void IsWithinRange_InvalidRange_ThrowsArgumentException(double minBoundary, double maxBoundary)
    {
        // Arrange
        Validator validator = new();
        double valueToTest = 0;

        // Assert => Act
        Assert.ThrowsException<ArgumentException>(() =>
            validator.IsWithinRange(valueToTest, minBoundary, maxBoundary));
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