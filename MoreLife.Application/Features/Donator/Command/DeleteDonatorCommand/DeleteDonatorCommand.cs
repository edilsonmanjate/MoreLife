using MediatR;

using MoreLife.Application.Common.Bases;

namespace MoreLife.Application.Features.Donators.Command.DeleteDonatorCommand;

public class DeleteDonatorCommand : IRequest<BaseResponse<bool>>
{
    public Guid Id { get; set; }
}