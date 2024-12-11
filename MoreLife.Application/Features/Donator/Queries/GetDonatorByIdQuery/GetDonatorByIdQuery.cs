using MediatR;

using MoreLife.Application.Common.Bases;
using MoreLife.Application.DTOs;

namespace MoreLife.Application.Features.Donators.Queries.GetDonatorByIdQuery;

public class GetDonatorByIdQuery : IRequest<BaseResponse<DonatorDto>>
{
    public Guid Id { get; set; }
}

