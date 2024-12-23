using AutoMapper;

using MediatR;

using MoreLife.Application.Common.Bases;
using MoreLife.Application.Common.Exceptions;
using MoreLife.Application.Repositories;
using MoreLife.core.Entities;

namespace MoreLife.Application.Features.Donators.Command.DeleteDonatorCommand;

public class DeleteDonatorCommandHandler : IRequestHandler<DeleteDonatorCommand, BaseResponse<bool>>
{
    private readonly IDonatorRepository _donatorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteDonatorCommandHandler(IDonatorRepository donatorRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _donatorRepository = donatorRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<bool>> Handle(DeleteDonatorCommand command, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {

            var donator = _mapper.Map<Donator>(command);
            response.Data = await _donatorRepository.Delete(donator);
            await _unitOfWork.Save(cancellationToken);

            if (response.Data)
            { 
                response.Success = true;
                response.Message = "Delete succeed!";
            }

        }
        catch (BadRequestException ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }

}
