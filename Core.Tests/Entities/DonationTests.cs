using MoreLife.core.Entities;

namespace MoreLife.Core.Tests.Entities;

public class DonationTests
{
    [Fact]
    public void CanCreateDonation()
    {
        // Arrange
        var donatorId = Guid.NewGuid();
        var date = DateTime.Now;
        var quantity = 500;

        // Act
        var donation = new Donation(donatorId, date, quantity);

        // Assert
        Assert.Equal(donatorId, donation.DonatorId);
        Assert.Equal(date, donation.Date);
        Assert.Equal(quantity, donation.Quantity);
    }

    [Fact]
    public void CanUpdateDonation()
    {
        // Arrange
        var donatorId = Guid.NewGuid();
        var donation = new Donation(donatorId, DateTime.Now, 500);
        var newDate = DateTime.Now.AddDays(1);
        var newQuantity = 600;
        var newDonatorId = Guid.NewGuid();

        // Act
        donation.UpdateDonation(newDate, newQuantity, newDonatorId);

        // Assert
        Assert.Equal(newDate, donation.Date);
        Assert.Equal(newQuantity, donation.Quantity);
        Assert.Equal(newDonatorId, donation.DonatorId);
    }
}