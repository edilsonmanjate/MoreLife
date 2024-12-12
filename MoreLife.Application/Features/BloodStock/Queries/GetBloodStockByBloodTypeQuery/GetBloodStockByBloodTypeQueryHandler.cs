using AutoMapper;

using MediatR;
using MoreLife.Application.Common.Bases;
using MoreLife.Application.DTOs;
using MoreLife.Application.Repositories;
using MoreLife.core.Enums;

namespace MoreLife.Application.Features.BloodStocks.Queries.GetBloodStockByBloodTypeQuerys;

public class GetBloodStockByBloodTypeQueryHandler : IRequestHandler<GetBloodStockByBloodTypeQuery, BaseResponse<BloodStockDto>>
{
    private readonly IBloodStockRepository _bloodStockRepository;
    private readonly IMapper _mapper;

    public GetBloodStockByBloodTypeQueryHandler(IBloodStockRepository bloodStockRepository, IMapper mapper)
    {
        _bloodStockRepository = bloodStockRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<BloodStockDto>> Handle(GetBloodStockByBloodTypeQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<BloodStockDto>();

        try
        {
            if (Enum.TryParse<BloodType>(request.bloodType, out var bloodType))
            {
                var book = await _bloodStockRepository.GetByBloodType(bloodType, request.rhFactor, cancellationToken);

                if (book is not null)
                {
                    response.Data = _mapper.Map<BloodStockDto>(book);
                    response.Success = true;
                    response.Message = "Query succeed!";
                }
            }
            else
            {
                response.Message = "Invalid blood type provided.";
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}
