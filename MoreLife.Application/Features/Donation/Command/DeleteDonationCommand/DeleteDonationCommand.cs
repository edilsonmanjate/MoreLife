using MediatR;
using MoreLife.Application.Common.Bases;

namespace MoreLife.Application.Features.Donations.Command.DeleteDonationCommand;

public class DeleteDonationCommand : IRequest<BaseResponse<bool>>
{
    public Guid Id { get; set; }
}