using MediatR;

using MoreLife.Application.Common.Bases;
using MoreLife.Application.DTOs;

namespace MoreLife.Application.Features.Dashboards.Queries;

public class GetDashboardQuery : IRequest<BaseResponse<DashboardDto>>
{
}
