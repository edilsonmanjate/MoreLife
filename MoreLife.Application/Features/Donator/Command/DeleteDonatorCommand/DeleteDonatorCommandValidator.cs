using FluentValidation;
using FluentValidation.Validators;

namespace MoreLife.Application.Features.Donators.Command.DeleteDonatorCommand;

public class DeleteDonatorCommandValidator : AbstractValidator<DeleteDonatorCommand>
{
    public DeleteDonatorCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .NotNull().WithMessage("Id is required");
    }
}
