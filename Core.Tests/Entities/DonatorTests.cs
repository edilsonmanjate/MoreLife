using MoreLife.core.Entities;
using MoreLife.core.Enums;
using MoreLife.core.ValueObjects;

namespace MoreLife.Core.Tests.Entities;

public class DonatorTests
{
    [Fact]
    public void CanCreateDonator()
    {
        // Arrange
        var name = "John Doe";
        var email = "john.doe@example.com";
        var birthDate = new DateOnly(1990, 1, 1);
        var genre = Genre.M;
        var weight = 70.5m;
        var height = 175.3m;
        var bloodType = BloodType.O;
        var rhFactor = "+";
        var address = new Address(Guid.NewGuid(), "Av 24 de Julho", "Maputo", "Cidade de Maputo", "12345");
        var donations = new List<Donation>();

        // Act
        var donator = new Donator(name, email, birthDate, genre, weight, height, bloodType, rhFactor, address, donations);

        // Assert
        Assert.Equal(name, donator.Name);
        Assert.Equal(email, donator.Email);
        Assert.Equal(birthDate, donator.BirthDate);
        Assert.Equal(genre, donator.Genre);
        Assert.Equal(weight, donator.Weight);
        Assert.Equal(height, donator.Height);
        Assert.Equal(bloodType, donator.BloodType);
        Assert.Equal(rhFactor, donator.RhFactor);
        Assert.Equal(address, donator.Address);
        Assert.Empty(donator.Donations);
    }

    [Fact]
    public void CanUpdatePersonalInfo()
    {
        // Arrange
        var donator = new Donator("John Doe", "john.doe@example.com", new DateOnly(1990, 1, 1), Genre.M, 70.5m, 175.3m, BloodType.O, "+", new Address(Guid.NewGuid(), "123 Main St", "Anytown", "Anystate", "12345"), new List<Donation>());
        var newName = "Jane Doe";
        var newEmail = "jane.doe@example.com";
        var newBirthDate = new DateOnly(1992, 2, 2);
        var newGenre = Genre.F;
        var newWeight = 65.0m;
        var newHeight = 165.0m;
        var newBloodType = BloodType.A;
        var newRhFactor = "-";
        var newAddress = new Address(Guid.NewGuid(), "Av 24 de Julho", "Matola", "Província de Maputo", "54321");

        // Act
        donator.UpdatePersonalInfo(newName, newEmail, newBirthDate, newGenre, newWeight, newHeight, newBloodType, newRhFactor, newAddress);

        // Assert
        Assert.Equal(newName, donator.Name);
        Assert.Equal(newEmail, donator.Email);
        Assert.Equal(newBirthDate, donator.BirthDate);
        Assert.Equal(newGenre, donator.Genre);
        Assert.Equal(newWeight, donator.Weight);
        Assert.Equal(newHeight, donator.Height);
        Assert.Equal(newBloodType, donator.BloodType);
        Assert.Equal(newRhFactor, donator.RhFactor);
        Assert.Equal(newAddress, donator.Address);
    }

    [Fact]
    public void CanAddDonation()
    {
        // Arrange
        var donator = new Donator("John Doe", "john.doe@example.com", new DateOnly(1990, 1, 1), Genre.M, 70.5m, 175.3m, BloodType.O, "+", new Address(Guid.NewGuid(), "Av 24 de Julho", "Maputo", "Cidade de Maputo", "12345"), new List<Donation>());
        var donation = new Donation(Guid.NewGuid(), DateTime.Now, 500);

        // Act
        donator.AddDonation(donation);

        // Assert
        Assert.Single(donator.Donations);
        Assert.Contains(donation, donator.Donations);
    }
}
