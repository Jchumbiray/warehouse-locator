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

}