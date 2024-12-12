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
        private readonly IMapper _mapper;

        public GetAllDonationsQueryHandler(IDonationRepository donationRepository, IMapper mapper)
        {
            _donationRepository = donationRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<DonationDto>>> Handle(GetAllDonationsQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<DonationDto>>();

            try
            {
                var books = await _donationRepository.GetAll(cancellationToken);

                if (books is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<DonationDto>>(books);
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
