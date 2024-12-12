using MoreLife.core.Enums;

namespace MoreLife.core.Entities;

public class Donation : BaseEntity
{
    public Donation(Guid donatorId, DateTime date, int quantity)
    {
        DonatorId = donatorId;
        Date = date;
        Quantity = quantity;
    }

    public Guid DonatorId { get; private set; }
    public Donator Donator { get; private set; }
    public DateTime Date { get; private set; }
    public int Quantity { get; private set; }

    public void UpdateDonation(DateTime date, int quantity, Guid donatorId)
    {
        DonatorId = donatorId;
        Date = date;
        Quantity = quantity;
    }

    public bool IsValidQuantity()
    {
        return Quantity < 420 || Quantity > 470 ?  false : true;
    }
}
