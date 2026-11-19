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




    [Theory]
    [InlineData("")]
    [InlineData("hola")]
    [InlineData("A-1-3")]
    public void Create_WithInvalidFormat_Throws(string value)
    {
        Assert.Throws<ArgumentException>(() => new LocationCode(value));
    }

}