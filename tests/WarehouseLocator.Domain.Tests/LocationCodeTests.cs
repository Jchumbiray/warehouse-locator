using WarehouseLocator.Domain;

namespace WarehouseLocator.Domain.Tests;

public class LocationCodeTests
{
    [Fact]
    public void Create_WithValidFormat_KeepsValue()
    {
        var code = new LocationCode("A-01-03");

        Assert.Equal("A-01-03", code.Value);
    }
}