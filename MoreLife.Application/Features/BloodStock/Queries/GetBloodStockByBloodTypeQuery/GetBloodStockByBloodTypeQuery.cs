using MediatR;

using MoreLife.Application.Common.Bases;
using MoreLife.Application.DTOs;
using MoreLife.core.Enums;

namespace MoreLife.Application.Features.BloodStocks.Queries.GetBloodStockByBloodTypeQuerys;

public class GetBloodStockByBloodTypeQuery : IRequest<BaseResponse<BloodStockDto>>, IBaseRequest
{
    public string bloodType { get; set; }
    public string rhFactor { get; set; }
}
