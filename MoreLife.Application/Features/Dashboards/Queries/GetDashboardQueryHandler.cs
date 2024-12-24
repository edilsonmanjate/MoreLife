using AutoMapper;

using MediatR;

using MoreLife.Application.Common.Bases;
using MoreLife.Application.Common.Exceptions;
using MoreLife.Application.DTOs;
using MoreLife.Application.Repositories;

using System.Text.Json;

namespace MoreLife.Application.Features.Dashboards.Queries;

public class GetDashboardQueryHandler : IRequestHandler<GetDashboardQuery, BaseResponse<DashboardDto>>
{
    private readonly IDashboardRepository _dashboardRepository;
    private readonly IMapper _mapper;

    public GetDashboardQueryHandler(IDashboardRepository dashboardRepository, IMapper mapper)
    {
        _dashboardRepository = dashboardRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<DashboardDto>> Handle(GetDashboardQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<DashboardDto>();

        try
        {
            var dashboard = await _dashboardRepository.GetDashboard(cancellationToken);
            if (dashboard == null)
            {
                response.Message = "Dashboard not found.";
                return response;
            }
            var dashboardDto = _mapper.Map<DashboardDto>(dashboard);

            if (dashboardDto is not null)
            {
                response.Data = dashboardDto;
                response.Success = true;
                response.Message = "Query succeed!";
            }
        }
        catch (BadRequestException ex)
        {
            response.Message = ex.Message;
        }
    
        return response;
    }

}
