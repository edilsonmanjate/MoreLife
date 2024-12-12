using AutoMapper;

using MoreLife.Application.DTOs;
using MoreLife.Application.Features.Donations.Command.CreateDonationCommand;
using MoreLife.Application.Features.Donations.Command.DeleteDonationCommand;
using MoreLife.Application.Features.Donators.Command.UpdateDonatorCommand;
using MoreLife.core.Entities;

namespace MoreLife.Application.Common.Mappings;

public class DonationMapper : Profile
{
    public DonationMapper()
    {
        CreateMap<Donation, DonationDto>();
        CreateMap<Donation, CreateDonationCommand>().ReverseMap();
        CreateMap<Donation, UpdateDonatorCommand>().ReverseMap();
        CreateMap<Donation, DeleteDonationCommand>().ReverseMap();

    }

}