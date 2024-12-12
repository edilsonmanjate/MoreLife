using MoreLife.core.Enums;

namespace MoreLife.core.Entities;

public class BloodStock : BaseEntity
{
    public BloodStock(Guid bloodTypeId, BloodType bloodType, int quantity, string rhFactor)
    {
        BloodTypeId = bloodTypeId;
        BloodType = bloodType;
        Quantity = quantity;
        RhFactor = rhFactor;
    }
    public Guid BloodTypeId { get; private set; }
    public BloodType BloodType { get; private set; }
    public int Quantity { get; private set; }
    public string RhFactor { get; private set; }

    public void UpdateQuantity(int newQuantity)
    {
        Quantity = newQuantity;
    }
}
