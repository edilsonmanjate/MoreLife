using MoreLife.core.Enums;

namespace MoreLife.Application.DTOs;

public class BloodStockDto
{
    public Guid Id { get;  set; }
    public BloodType BloodType { get;  set; }
    public int Quantity { get;  set; }
    public string RhFactor { get;  set; }
}
