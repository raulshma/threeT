using FluentValidation;

namespace ThreeTee.Application.Cqrs.Projects.Commands.CreateProject;
public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(e=>e.Name)
            .NotEmpty();
        RuleFor(e => e.ClientId)
            .NotEmpty();
        RuleFor(e=>e.StartDate) 
            .NotEmpty();
    }
}

