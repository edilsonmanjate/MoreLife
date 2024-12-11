using AutoMapper;

using MediatR;

using MoreLife.Application.Common.Bases;
using MoreLife.Application.Common.Exceptions;
using MoreLife.Application.DTOs;
using MoreLife.Application.Repositories;

namespace MoreLife.Application.Features.Donators.Queries.GetAllDonatorsQuery;

public class GetAllDonatorQueryHandler : IRequestHandler<GetAllDonatorQuery, BaseResponse<IEnumerable<DonatorDto>>>
{
    private readonly IDonatorRepository _donatorRepository;
    private readonly IMapper _mapper;

    public GetAllDonatorQueryHandler(IDonatorRepository donatorRepository, IMapper mapper)
    {
        _donatorRepository = donatorRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<IEnumerable<DonatorDto>>> Handle(GetAllDonatorQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<DonatorDto>>();

        try
        {
            var books = await _donatorRepository.GetAll(cancellationToken);

            if (books is not null)
            {
                response.Data = _mapper.Map<IEnumerable<DonatorDto>>(books);
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
