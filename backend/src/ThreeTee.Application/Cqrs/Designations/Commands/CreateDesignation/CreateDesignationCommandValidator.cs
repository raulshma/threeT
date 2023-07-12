using FluentValidation;

namespace ThreeTee.Application.Cqrs.Designations.Commands.CreateDesignation;
public class CreateDesignationCommandValidator : AbstractValidator<CreateDesignationCommand>
{
    public CreateDesignationCommandValidator()
    {
        RuleFor(e => e.Name)
            .NotEmpty();
    }
}

