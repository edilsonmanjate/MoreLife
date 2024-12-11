using AutoMapper;

using MediatR;
using MoreLife.Application.Common.Bases;
using MoreLife.Application.Common.Exceptions;
using MoreLife.Application.DTOs;
using MoreLife.Application.Repositories;

namespace MoreLife.Application.Features.Donators.Queries.GetDonatorByIdQuery;

public class GetDonatorByIdQueryHandler : IRequestHandler<GetDonatorByIdQuery, BaseResponse<DonatorDto>>
{
    private readonly IDonatorRepository _donatorRepository;
    private readonly IMapper _mapper;

    public GetDonatorByIdQueryHandler(IDonatorRepository donatorRepository, IMapper mapper)
    {
        _donatorRepository = donatorRepository;
        _mapper = mapper;
    }
    public async Task<BaseResponse<DonatorDto>> Handle(GetDonatorByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<DonatorDto>();

        try
        {
            var book = await _donatorRepository.Get(request.Id, cancellationToken);

            if (book is not null)
            {
                response.Data = _mapper.Map<DonatorDto>(book);
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
