using WarehouseLocator.Domain;

namespace WarehouseLocator.Domain.Tests;

public class LocationTests
{
    [Fact]
    public void NewLocation_WithNoUnits_IsAvailable()
    {
        // Arrange
        var location = new Location("A-01-03", 100);

        // Act
        var status = location.Status;

        // Assert
        Assert.Equal(LocationStatus.Available, status);
    }



    [Fact]
    public void LocationWithSomeUnits_BelowCapacity_IsPartial()
    {
        // Arrange
        var location = new Location("A-01-03", 100);

        // Act
        location.AddUnits(60);

        // Assert
        Assert.Equal(LocationStatus.Partial, location.Status);
    }



    [Fact]
    public void LocationAtFullCapacity_IsFull()
    {
        // Arrange
        var location = new Location("A-01-03", 100);

        // Act
        location.AddUnits(100);

        // Assert
        Assert.Equal(LocationStatus.Full, location.Status);
    }


    [Fact]
    public void BlockedLocation_IsBlocked()
    {
        var location = new Location("A-01-03", 100);

        location.Block();

        Assert.Equal(LocationStatus.Blocked, location.Status);
    }



    [Fact]
    public void AddUnits_ToBlockedLocation_Throws()
    {
        var location = new Location("A-01-03", 100);
        location.Block();

        Assert.Throws<InvalidOperationException>(() => location.AddUnits(10));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void AddUnits_WithZeroOrNegativeQuantity_Throws(int quantity)
    {
        var location = new Location("A-01-03", 100);

        Assert.Throws<ArgumentException>(() => location.AddUnits(quantity));
    }


}