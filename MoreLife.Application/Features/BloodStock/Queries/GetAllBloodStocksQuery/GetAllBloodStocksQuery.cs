using MediatR;

using MoreLife.Application.Common.Bases;
using MoreLife.Application.DTOs;

namespace MoreLife.Application.Features.BloodStocks.Queries.GetAllBloodStocksQuery;

public class GetAllBloodStocksQuery : IRequest<BaseResponse<IEnumerable<BloodStockDto>>>
{
}