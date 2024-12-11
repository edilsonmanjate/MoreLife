using FluentValidation;

using MoreLife.core.ValueObjects;

namespace MoreLife.Application.Features.Donators.Command.UpdateDonatorCommand;

public class UpdateDonatorCommandValidator : AbstractValidator<UpdateDonatorCommand>
{
    public UpdateDonatorCommandValidator()
    {
        RuleFor(d => d.Id)
            .NotEmpty().WithMessage("Id is required.")
            .NotNull().WithMessage("Id is required");

        RuleFor(d => d.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(d => d.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(d => d.BirthDate)
            .NotEmpty().WithMessage("BirthDate is required.")
            .LessThan(DateOnly.FromDateTime(DateTime.Now)).WithMessage("BirthDate must be in the past.")
            .Must(BeAtLeast18YearsOld).WithMessage("Donator must be at least 18 years old.");

        RuleFor(d => d.Genre)
            .IsInEnum().WithMessage("Invalid genre.");

        RuleFor(d => d.Weight)
            .GreaterThan(0).WithMessage("Weight must be greater than 0.");

        RuleFor(d => d.Height)
            .GreaterThan(0).WithMessage("Height must be greater than 0.");
        RuleFor(d => d.BloodType)
            .IsInEnum().WithMessage("Invalid blood type.");

        RuleFor(d => d.HRFactor)
            .NotEmpty().WithMessage("HRFactor is required.");

        RuleFor(d => d.Address)
            .NotNull().WithMessage("Address is required.")
            .SetValidator(new AddressValidator());
    }

    private bool BeAtLeast18YearsOld(DateOnly birthDate)
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        var age = today.Year - birthDate.Year;
        if (birthDate > today.AddYears(-age)) age--;
        return age >= 18;
    }
}

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
            .NotEmpty().WithMessage("PostalCode is required.")
            .Matches(@"^\d{5}(-\d{4})?$").WithMessage("Invalid PostalCode format.");
    }
}
