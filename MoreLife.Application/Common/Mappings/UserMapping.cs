using AutoMapper;

using MoreLife.Application.DTOs;
using MoreLife.core.Entities;

namespace MoreLife.Application.Common.Mappings;

public class UserMApping : Profile
{
    public UserMApping()
    {
        CreateMap<User, UserDto>().ReverseMap();

    }
}
