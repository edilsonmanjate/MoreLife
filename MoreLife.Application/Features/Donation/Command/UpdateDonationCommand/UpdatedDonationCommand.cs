using MediatR;
using MoreLife.Application.Common.Bases;

namespace MoreLife.Application.Features.Donations.Command.UpdateDonationCommand;

public class UpdatedDonationCommand : IRequest<BaseResponse<bool>>
{
    public Guid Id { get;  set; }
    public Guid DonatorId { get;  set; }
    public DateTime Date { get;  set; }
    public int Quantity { get;  set; }
}