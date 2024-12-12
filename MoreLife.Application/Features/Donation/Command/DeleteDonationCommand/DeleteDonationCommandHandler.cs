﻿using AutoMapper;

using MediatR;
using MoreLife.Application.Common.Bases;
using MoreLife.Application.Common.Exceptions;
using MoreLife.Application.Repositories;
using MoreLife.core.Entities;

namespace MoreLife.Application.Features.Donations.Command.DeleteDonationCommand;

public class DeleteDonationCommandHandler : IRequestHandler<DeleteDonationCommand, BaseResponse<bool>>
{
    private readonly IDonationRepository _donationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteDonationCommandHandler(IDonationRepository donationRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _donationRepository = donationRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<bool>> Handle(DeleteDonationCommand command, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var donation = _mapper.Map<Donation>(command);
            response.Data = await _donationRepository.Delete(donation);
            await _unitOfWork.Save(cancellationToken);

            if (response.Data)
                response.Success = true;
            response.Message = "Delete succeed!";

        }
        catch (BadRequestException ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}