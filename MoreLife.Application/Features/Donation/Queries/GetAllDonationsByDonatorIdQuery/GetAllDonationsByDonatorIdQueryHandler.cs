using AutoMapper;

using MediatR;

using MoreLife.Application.Common.Bases;
using MoreLife.Application.Common.Exceptions;
using MoreLife.Application.DTOs;
using MoreLife.Application.Repositories;

namespace MoreLife.Application.Features.Donations.Queries.GetAllDonationsByDonatorIdQuery;

public class GetAllDonationsByDonatorIdQueryHandler : IRequestHandler<GetAllDonationsByDonatorIdQuery, BaseResponse<DonationDto>>
{
    private readonly IDonationRepository _donationRepository;
    private readonly IMapper _mapper;

    public GetAllDonationsByDonatorIdQueryHandler(IDonationRepository donationRepository, IMapper mapper)
    {
        _donationRepository = donationRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<DonationDto>> Handle(GetAllDonationsByDonatorIdQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<DonationDto>();

        try
        {
            var donation = await _donationRepository.GetByDonatorId(request.DonatorId, cancellationToken);

            if (donation is not null)
            {
                var donationDto = _mapper.Map<DonationDto>(donation);

                

                response.Data = donationDto;
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
