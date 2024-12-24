namespace MoreLife.Application.DTOs;

public class DonationDto
{
    public Guid Id { get;  set; }
    public Guid DonatorId { get;  set; }
    public string DonatorName { get; set; }
    public DateOnly Date { get;  set; }
    public int Quantity { get;  set; }
    
}
