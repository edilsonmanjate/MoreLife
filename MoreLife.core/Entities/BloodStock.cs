using MoreLife.core.Enums;

namespace MoreLife.core.Entities;

public class BloodStock : BaseEntity
{
    public BloodStock(Guid bloodTypeId, BloodType bloodType, int quantity, string hrFactor)
    {
        BloodTypeId = bloodTypeId;
        BloodType = bloodType;
        Quantity = quantity;
        RHFactor = hrFactor;
    }
    public Guid BloodTypeId { get; private set; }
    public BloodType BloodType { get; private set; }
    public int Quantity { get; private set; }
    public string RHFactor { get; private set; }

    public void UpdateQuantity(int newQuantity)
    {
        Quantity = newQuantity;
    }
}
