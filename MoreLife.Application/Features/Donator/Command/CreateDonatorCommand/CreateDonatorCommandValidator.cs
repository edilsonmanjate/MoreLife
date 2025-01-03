﻿using FluentValidation;

using MoreLife.core.ValueObjects;

namespace MoreLife.Application.Features.Donators.Command.CreateDonatorCommand;
public class CreateDonatorCommandValidator : AbstractValidator<CreateDonatorCommand>
{
    public CreateDonatorCommandValidator()
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
            .GreaterThan(49).WithMessage($"Weight must be greater than 49.");

        RuleFor(d => d.Height)
            .GreaterThan(0).WithMessage("Height must be greater than 0.");
        RuleFor(d => d.BloodType)
            .IsInEnum().WithMessage("Invalid blood type.");

        RuleFor(d => d.RhFactor)
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


