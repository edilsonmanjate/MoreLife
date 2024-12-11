using MediatR;

using MoreLife.Application.Common.Bases;
using MoreLife.core.Enums;
using MoreLife.core.ValueObjects;

namespace MoreLife.Application.Features.Donators.Command.CreateDonatorCommand;

public class CreateDonatorCommand : IRequest<BaseResponse<bool>>
{
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public Genre Genre { get; private set; }
    public decimal Weight { get; private set; }
    public decimal Height { get; private set; }
    public BloodType BloodType { get; private set; }
    public string HRFactor { get; private set; }
    public Address Address { get; private set; }
}
