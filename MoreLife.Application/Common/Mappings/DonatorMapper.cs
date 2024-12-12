using AutoMapper;

using MoreLife.Application.DTOs;
using MoreLife.Application.Features.Donators.Command.CreateDonatorCommand;
using MoreLife.Application.Features.Donators.Command.DeleteDonatorCommand;
using MoreLife.Application.Features.Donators.Command.UpdateDonatorCommand;
using MoreLife.core.Entities;

namespace MoreLife.Application.Common.Mappings;

public class DonatorMapper : Profile
{
    public DonatorMapper()
    {
        CreateMap<Donator, DonatorDto>().ReverseMap();
        CreateMap<Donator, CreateDonatorCommand>().ReverseMap();
        CreateMap<DonatorDto, CreateDonatorCommand>().ReverseMap();
        CreateMap<Donator, UpdateDonatorCommand>().ReverseMap();
        CreateMap<Donator, DeleteDonatorCommand>().ReverseMap();

    }

}
