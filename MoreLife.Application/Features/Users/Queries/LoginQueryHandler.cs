using AutoMapper;

using MediatR;

using MoreLife.Application.Common.Bases;
using MoreLife.Application.Common.Exceptions;
using MoreLife.Application.DTOs;
using MoreLife.Application.Repositories;
using MoreLife.Application.Services;

namespace MoreLife.Application.Features.Users.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, BaseResponse<UserViewModel>>
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoginQueryHandler(IUserRepository userRepository, IMapper mapper, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<BaseResponse<UserViewModel>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<UserViewModel>();

            try
            {
                var user = await _userRepository.ValidateUserAsync(request.Email, request.Password);

                if (user is not null)
                {
                    
                    var token = _tokenService.GenerateToken(user);

                    var userVM = new UserViewModel
                    {
                        Email = user.Email,
                        Token = token.ToString()
                    };

                    response.Data = userVM;
                    response.Success = true;
                    response.Message = "Authentication succeed!";
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
