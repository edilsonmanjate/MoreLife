using AutoMapper;

using MediatR;

using MoreLife.Application.Common.Bases;
using MoreLife.Application.Repositories;
using MoreLife.core.Entities;

namespace MoreLife.Application.Features.Donators.Command.UpdateDonatorCommand;

public class UpdateDonatorCommandHandler : IRequestHandler<UpdateDonatorCommand, BaseResponse<bool>>
{
    private readonly IDonatorRepository _donatorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateDonatorCommandHandler(IDonatorRepository donatorRepository, IMapper mapper)
    {
        _donatorRepository = donatorRepository;
        _mapper = mapper;
    }
    public async Task<BaseResponse<bool>> Handle(UpdateDonatorCommand command, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var book = _mapper.Map<Donator>(command);
            response.Data = await _donatorRepository.Update(book);
            await _unitOfWork.Save(cancellationToken);

            if (response.Data)
            {
                response.Success = true;
                response.Message = "Update succeed!";
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}
