namespace MoreLife.Application.DTOs;

public class DonationDto
{
    public Guid Id { get;  set; }
    public Guid DonatorId { get;  set; }
    public DateTime Date { get;  set; }
    public int Quantity { get;  set; }
}
