using MediatR;

using MoreLife.Application.Common.Bases;
using MoreLife.Application.DTOs;

namespace MoreLife.Application.Features.Donations.Queries.GetAllDonationsByDonatorIdQuery;

public class GetAllDonationsByDonatorIdQuery : IRequest<BaseResponse<DonationDto>>
{
    public Guid DonatorId { get; set; }
}