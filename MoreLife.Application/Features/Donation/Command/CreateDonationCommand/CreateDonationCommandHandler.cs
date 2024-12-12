using AutoMapper;

using MediatR;

using MoreLife.Application.Common.Bases;
using MoreLife.Application.Common.Exceptions;
using MoreLife.Application.Repositories;
using MoreLife.core.Entities;
using MoreLife.core.Events;

namespace MoreLife.Application.Features.Donations.Command.CreateDonationCommand;

public class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, BaseResponse<bool>>
{
    private readonly IDonationRepository _donationRepository;
    private readonly IDonatorRepository _donatorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    public CreateDonationCommandHandler(IDonationRepository donationRepository, IUnitOfWork unitOfWork, IMapper mapper, IDonatorRepository donatorRepository, IMediator mediator)
    {
        _donationRepository = donationRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _donatorRepository = donatorRepository;
        _mediator = mediator;
    }

    public async Task<BaseResponse<bool>> Handle(CreateDonationCommand command, CancellationToken cancellationToken)
    {
        

        var response = new BaseResponse<bool>();
        try
        {
            var donation = _mapper.Map<Donation>(command);

            var lastDonation = await _donationRepository.GetByDonatorId(command.DonatorId, cancellationToken);

            var lastDonationDate = lastDonation is not null ? lastDonation.OrderByDescending(d => d.Date).FirstOrDefault() : null;

            var donator = await _donatorRepository.Get(command.DonatorId, cancellationToken);


            if (lastDonationDate is null || donation.CanDonate(lastDonationDate.Date, donator))
            {
                response.Data = await _donationRepository.Create(donation);
                await _unitOfWork.Save(cancellationToken);

                if (response.Data)
                {
                    response.Success = true;
                    response.Message = "Donation created successfully";

                    // Disparar evento de domínio
                    await _mediator.Publish(new DonationCreatedEvent(donation), cancellationToken);
                }
            }

        }
        catch (BadRequestException ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}
