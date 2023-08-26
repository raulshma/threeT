using FluentValidation;

namespace ThreeTee.Application.Cqrs.Modules.Commands.DeleteModule;
public class DeleteModuleCommandValidator:AbstractValidator<DeleteModuleCommand>
{
    public DeleteModuleCommandValidator()
    {
        RuleFor(e => e.Id)
           .NotEmpty();
    }
}

