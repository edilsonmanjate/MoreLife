using AutoMapper;

using MoreLife.Application.DTOs;
using MoreLife.core.Entities;

namespace MoreLife.Application.Common.Mappings
{
    public class BloodStockMapper : Profile
    {
        public BloodStockMapper()
        {
            CreateMap<BloodStock, BloodStockDto>();
        }
    }
}
