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
}