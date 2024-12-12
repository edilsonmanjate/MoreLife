using MediatR;

using MoreLife.Application.Common.Bases;
using MoreLife.core.Enums;
using MoreLife.core.ValueObjects;

namespace MoreLife.Application.Features.Donators.Command.CreateDonatorCommand;

public class CreateDonatorCommand : IRequest<BaseResponse<bool>>
{
    public Guid Id { get; set; }
    public string Name { get;  set; }
    public string Email { get;  set; }
    public DateOnly BirthDate { get;  set; }
    public Genre Genre { get;  set; }
    public decimal Weight { get;  set; }
    public decimal Height { get;  set; }
    public BloodType BloodType { get;  set; }
    public string RhFactor { get;  set; }
    public Address Address { get;  set; }
}
