using MoreLife.core.Enums;
using MoreLife.core.ValueObjects;

namespace MoreLife.Application.DTOs;

public class DonatorDto
{
    public Guid Id { get; set; }
    public string Name { get;  set; }
    public string Email { get;  set; }
    public DateOnly BirthDate { get;  set; }
    public Genre Genre { get;  set; }
    public decimal Weight { get;  set; }
    public decimal Height { get;  set; }
    public BloodType BloodType { get;  set; }
    public string HRFactor { get;  set; }
    public Address Address { get;  set; }
}
