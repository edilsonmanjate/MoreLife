using MoreLife.core.ValueObjects;

namespace MoreLife.Core.Tests.ValueObjects;

public class AddressTests
{
    [Fact]
    public void CanCreateAddress()
    {
        // Arrange
        var id = Guid.NewGuid();
        var street = "Rua da SADC";
        var city = "Maputo";
        var state = "Cidade de Maputo";
        var postalCode = "12345";

        // Act
        var address = new Address(id, street, city, state, postalCode);

        // Assert
        Assert.Equal(id, address.Id);
        Assert.Equal(street, address.Street);
        Assert.Equal(city, address.City);
        Assert.Equal(state, address.State);
        Assert.Equal(postalCode, address.PostalCode);
    }

    [Fact]
    public void AddressesWithSameValuesAreEqual()
    {
        // Arrange
        var id = Guid.NewGuid();
        var street = "Rua da SADC";
        var city = "Maputo";
        var state = "Cidade de Maputo";
        var postalCode = "12345";

        var address1 = new Address(id, street, city, state, postalCode);
        var address2 = new Address(id, street, city, state, postalCode);

        // Act & Assert
        Assert.Equal(address1, address2);
        Assert.True(address1.Equals(address2));
        Assert.Equal(address1.GetHashCode(), address2.GetHashCode());
    }

    [Fact]
    public void AddressesWithDifferentValuesAreNotEqual()
    {
        // Arrange
        var address1 = new Address(Guid.NewGuid(), "Av 25 de Setembro", "Maputo", "Maputo", "12345");
        var address2 = new Address(Guid.NewGuid(), "Av 25 Eduardo Mandlane", "Maputo", "Maputo", "12345");

        // Act & Assert
        Assert.NotEqual(address1, address2);
        Assert.False(address1.Equals(address2));
        Assert.NotEqual(address1.GetHashCode(), address2.GetHashCode());
    }
}