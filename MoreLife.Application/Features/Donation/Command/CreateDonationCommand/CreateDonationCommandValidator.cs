using FluentValidation;

namespace MoreLife.Application.Features.Donations.Command.CreateDonationCommand;

public class CreateDonationCommandValidator : AbstractValidator<CreateDonationCommand>
{
    public CreateDonationCommandValidator()
    {
        RuleFor(p => p.Id)
                 .NotEmpty().WithMessage("{PropertyName} is required.")
                 .NotNull().WithMessage("{PropertyName} is required");

        RuleFor(p => p.DonatorId)
                 .NotEmpty().WithMessage("{PropertyName} is required.")
                 .NotNull().WithMessage("{PropertyName} is required");

        RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{PropertyName}  is required.");

        RuleFor(d => d.Quantity)
            .GreaterThan(420).WithMessage("{PropertyName} must be greater than 420ml.")
            .LessThan(470).WithMessage("{PropertyName} must be Less than 470ml.");

    }

}
