using FluentValidation;

using MoreLife.core.ValueObjects;

namespace MoreLife.Application.Features.Donators.Command.CreateDonatorCommand;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(a => a.Id)
            .NotEmpty().WithMessage("Address Id is required.");

        RuleFor(a => a.Street)
            .NotEmpty().WithMessage("Street is required.")
            .MaximumLength(200).WithMessage("Street must not exceed 200 characters.");

        RuleFor(a => a.City)
            .NotEmpty().WithMessage("City is required.")
            .MaximumLength(100).WithMessage("City must not exceed 100 characters.");

        RuleFor(a => a.State)
            .NotEmpty().WithMessage("State is required.")
            .MaximumLength(100).WithMessage("State must not exceed 100 characters.");

        RuleFor(a => a.PostalCode)
            .NotEmpty().WithMessage("PostalCode is required.");


    }
}