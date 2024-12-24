using AutoMapper;

using MediatR;

using MoreLife.Application.Common.Bases;
using MoreLife.Application.Common.Exceptions;
using MoreLife.Application.DTOs;
using MoreLife.Application.Repositories;

namespace MoreLife.Application.Features.Donations.Queries.GetAllDonationsQuery
{
    public class GetAllDonationsQueryHandler : IRequestHandler<GetAllDonationsQuery, BaseResponse<IEnumerable<DonationDto>>>
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IDonatorRepository _donatorRepository;
        private readonly IMapper _mapper;

        public GetAllDonationsQueryHandler(IDonationRepository donationRepository, IMapper mapper, IDonatorRepository donatorRepository)
        {
            _donationRepository = donationRepository;
            _mapper = mapper;
            _donatorRepository = donatorRepository;
        }

        public async Task<BaseResponse<IEnumerable<DonationDto>>> Handle(GetAllDonationsQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<DonationDto>>();

            try
            {
                var donations = await _donationRepository.GetAll(cancellationToken);
                var donationDtos = _mapper.Map<IEnumerable<DonationDto>>(donations);

                foreach (var donationDto in donationDtos)
                {
                    var donator = await _donatorRepository.Get(donationDto.DonatorId, cancellationToken);
                    donationDto.DonatorName = donator.Name;
                }

                if (donations is not null)
                {
                    response.Data = donationDtos;
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
}
