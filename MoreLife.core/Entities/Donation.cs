using MoreLife.core.Enums;

namespace MoreLife.core.Entities;

public class Donation : BaseEntity
{
    public Donation(Guid donatorId, DateOnly date, int quantity)
    {
        DonatorId = donatorId;
        Date = date;
        Quantity = quantity;
    }

    public Guid DonatorId { get; private set; }
    public Donator Donator { get; private set; }
    public DateOnly Date { get; private set; }
    public int Quantity { get; private set; }


    public void UpdateDonation(DateOnly date, int quantity, Guid donatorId)
    {
        DonatorId = donatorId;
        Date = date;
        Quantity = quantity;
    }

    public bool CanDonate(DateOnly lastDonationDate, Donator donator)
    {

        if (donator.Weight < 50)
            throw new Exception("Insufficient weight to donate.");

        var daysSinceLastDonation = (Date.ToDateTime(TimeOnly.MinValue) - lastDonationDate.ToDateTime(TimeOnly.MinValue)).Days;

        if (donator.Genre == Genre.Female && daysSinceLastDonation < 90)
            throw new Exception("Women can only donate every 90 days.");

        if (donator.Genre == Genre.Male && daysSinceLastDonation < 60)
            throw new Exception("Men can only donate every 60 days.");

        return true;
    }

}
