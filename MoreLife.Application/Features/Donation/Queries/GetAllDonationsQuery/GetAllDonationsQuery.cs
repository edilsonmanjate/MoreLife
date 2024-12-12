using MediatR;
using MoreLife.Application.Common.Bases;
using MoreLife.Application.DTOs;

namespace MoreLife.Application.Features.Donations.Queries.GetAllDonationsQuery;

public class GetAllDonationsQuery : IRequest<BaseResponse<IEnumerable<DonationDto>>>
{
}
