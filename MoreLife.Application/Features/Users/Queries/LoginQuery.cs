using MediatR;

using MoreLife.Application.Common.Bases;
using MoreLife.Application.DTOs;

namespace MoreLife.Application.Features.Users.Queries;

public class LoginQuery : IRequest<BaseResponse<UserViewModel>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
