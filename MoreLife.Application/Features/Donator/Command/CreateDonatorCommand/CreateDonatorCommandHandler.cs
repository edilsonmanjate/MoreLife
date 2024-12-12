using AutoMapper;

using MediatR;

using MoreLife.Application.Common.Bases;
using MoreLife.Application.Common.Exceptions;
using MoreLife.Application.DTOs;
using MoreLife.Application.Repositories;
using MoreLife.Application.Services;
using MoreLife.core.Entities;
using MoreLife.core.ValueObjects;

namespace MoreLife.Application.Features.Donators.Command.CreateDonatorCommand;

public class CreateDonatorCommandHandler : IRequestHandler<CreateDonatorCommand, BaseResponse<bool>>
{
    private readonly IDonatorRepository _donatorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    private readonly IPostalCodeService _postalCodeService;

    public CreateDonatorCommandHandler(IDonatorRepository donatorRepository, IUnitOfWork unitOfWork, IMapper mapper, IPostalCodeService postalCodeService)
    {
        _donatorRepository = donatorRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _postalCodeService = postalCodeService;
    }

    public async Task<BaseResponse<bool>> Handle(CreateDonatorCommand command, CancellationToken cancellationToken)
    {
        var isEmailUnique = await _donatorRepository.IsEmailUnique(command.Email);
        if (!isEmailUnique)
            throw new BadRequestException("Email is already in use.");

        var response = new BaseResponse<bool>();

        try
        {
            var donatorDto = _mapper.Map<DonatorDto>(command);

            // performing postal code check
            var address = new Address(Guid.NewGuid(), command.Address.Street, command.Address.PostalCode, command.Address.City, command.Address.State);
          
            if (command.Address.PostalCode.Any())
            {
                var postalCodeDto = await _postalCodeService.CheckPostalCodeAsync(command.Address.PostalCode);
                if (postalCodeDto is not null)
                {
                    address = new Address(Guid.NewGuid(), postalCodeDto.Street, postalCodeDto.PostalCode, postalCodeDto.City, postalCodeDto.State);

                }
            }
            donatorDto.Address = address;

            var donator = _mapper.Map<Donator>(donatorDto);

            response.Data = await _donatorRepository.Create(donator);
            await _unitOfWork.Save(cancellationToken);

            if (response.Data)
            {
                response.Success = true;
                response.Message = "Donator created successfully";
            }

        }
        catch (BadRequestException ex)
        {
            response.Message = ex.Message;
        }
        return response;
    }
}
