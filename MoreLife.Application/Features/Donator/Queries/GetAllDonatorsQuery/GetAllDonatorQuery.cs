using MediatR;

using MoreLife.Application.Common.Bases;
using MoreLife.Application.DTOs;

namespace MoreLife.Application.Features.Donators.Queries.GetAllDonatorsQuery;

public class GetAllDonatorQuery : IRequest<BaseResponse<IEnumerable<DonatorDto>>>
{
}
