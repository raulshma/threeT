using FluentValidation;

namespace ThreeTee.Application.Cqrs.Designations.Commands.UpdateDesignation;
public class UpdateDesignationCommandValidator : AbstractValidator<UpdateDesignationCommand>
{
    public UpdateDesignationCommandValidator()
    {
        RuleFor(e => e.Name)
            .NotEmpty();
        RuleFor(e => e.Id)
            .NotEmpty();
    }
}

