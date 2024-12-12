using AutoMapper;

using MediatR;

using MoreLife.Application.Common.Bases;
using MoreLife.Application.DTOs;
using MoreLife.Application.Repositories;

namespace MoreLife.Application.Features.BloodStocks.Queries.GetAllBloodStocksQuery;

public class GetAllBloodStocksQueryHandler : IRequestHandler<GetAllBloodStocksQuery, BaseResponse<IEnumerable<BloodStockDto>>>
{
    private readonly IBloodStockRepository _bloodStockRepository;
    private readonly IMapper _mapper;

    public GetAllBloodStocksQueryHandler(IBloodStockRepository bloodStockRepository, IMapper mapper)
    {
        _bloodStockRepository = bloodStockRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<IEnumerable<BloodStockDto>>> Handle(GetAllBloodStocksQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<BloodStockDto>>();

        try
        {
            var bloodStock = await _bloodStockRepository.GetAll(cancellationToken);

            if (bloodStock is not null)
            {
                response.Data = _mapper.Map<IEnumerable<BloodStockDto>>(bloodStock);
                response.Success = true;
                response.Message = "Query succeed!";
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}
