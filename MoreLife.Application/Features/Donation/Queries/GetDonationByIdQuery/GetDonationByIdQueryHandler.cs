using AutoMapper;

using MediatR;
using MoreLife.Application.Common.Bases;
using MoreLife.Application.Common.Exceptions;
using MoreLife.Application.DTOs;
using MoreLife.Application.Repositories;

namespace MoreLife.Application.Features.Donations.Queries.GetDonationByIdQuery;

public class GetDonationByIdQueryHandler : IRequestHandler<GetDonationByIdQuery, BaseResponse<DonationDto>>
{
    private readonly IDonationRepository _donationRepository;
    private readonly IMapper _mapper;

    public GetDonationByIdQueryHandler(IDonationRepository donationRepository, IMapper mapper)
    {
        _donationRepository = donationRepository;
        _mapper = mapper;
    }

    public async  Task<BaseResponse<DonationDto>> Handle(GetDonationByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<DonationDto>();

        try
        {
            var book = await _donationRepository.Get(request.Id, cancellationToken);

            if (book is not null)
            {
                response.Data = _mapper.Map<DonationDto>(book);
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
