using AutoMapper;

using MoreLife.Application.DTOs;
using MoreLife.core.Entities;

namespace MoreLife.Application.Common.Mappings;

public class DashboardMapper : Profile
{
    public DashboardMapper()
    {
        CreateMap<Dashboard, DashboardDto>();
    }
}