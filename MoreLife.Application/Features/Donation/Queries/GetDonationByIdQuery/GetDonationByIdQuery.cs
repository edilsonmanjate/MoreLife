using MediatR;
using MoreLife.Application.Common.Bases;
using MoreLife.Application.DTOs;

namespace MoreLife.Application.Features.Donations.Queries.GetDonationByIdQuery;

public class GetDonationByIdQuery : IRequest<BaseResponse<DonationDto>>
{
    public Guid Id { get; set; }
}