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


    [Fact]
    public void AddUnits_ExceedingCapacity_Throws()
    {
        var location = new Location("A-01-03", 100);
        location.AddUnits(90);

        Assert.Throws<InvalidOperationException>(() => location.AddUnits(20));
    }


    [Fact]
    public void RemoveUnits_ReducesUnits()
    {
        var location = new Location("A-01-03", 100);
        location.AddUnits(50);

        location.RemoveUnits(20);

        Assert.Equal(30, location.Units);
    }



    [Fact]
    public void RemoveUnits_MoreThanAvailable_Throws()
    {
        var location = new Location("A-01-03", 100);
        location.AddUnits(30);

        Assert.Throws<InvalidOperationException>(() => location.RemoveUnits(50));
    }



    [Fact]
    public void RemoveUnits_FromBlockedLocation_IsAllowed()
    {
        var location = new Location("A-01-03", 100);
        location.AddUnits(40);
        location.Block();

        location.RemoveUnits(10);

        Assert.Equal(30, location.Units);
    }


    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void RemoveUnits_WithZeroOrNegativeQuantity_Throws(int quantity)
    {
        var location = new Location("A-01-03", 100);
        location.AddUnits(30);

        Assert.Throws<ArgumentException>(() => location.RemoveUnits(quantity));
    }





    [Fact]
    public void MoveUnitsTo_SameLocation_Throws()
    {
        var location = new Location("A-01-03", 100);
        location.AddUnits(30);
        Assert.Throws<InvalidOperationException>(() => location.MoveUnitsTo(location, 10));
    }





    [Fact]
    public void MoveUnitsTo_BlockedDestination_Throws_AndKeepsOriginUnits()
    {
        var origin = new Location("A-01-03", 100);
        origin.AddUnits(30);
        var destination = new Location("B-02-01", 100);
        destination.Block();

        Assert.Throws<InvalidOperationException>(() => origin.MoveUnitsTo(destination, 10));
        Assert.Equal(30, origin.Units);
    }

}