using FluentValidation;

namespace ThreeTee.Application.Cqrs.Modules.Commands.UpdateModule;
public class UpdateModuleCommandValidator:AbstractValidator<UpdateModuleCommand>
{
    public UpdateModuleCommandValidator()
    {
        RuleFor(e => e.Id).
          NotEmpty();
        RuleFor(e => e.Name).
            NotEmpty();
        RuleFor(e=>e.ProjectId).
            NotEmpty();
    }
}

