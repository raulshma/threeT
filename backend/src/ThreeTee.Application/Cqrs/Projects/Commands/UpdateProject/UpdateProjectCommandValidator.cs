using FluentValidation;

namespace ThreeTee.Application.Cqrs.Projects.Commands.UpdateProject;
public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
{
  public  UpdateProjectCommandValidator()
    {
      RuleFor(e=>e.Id)
            .NotEmpty();
        RuleFor(e => e.Name)
            .NotEmpty();
        RuleFor(e => e.StartDate)
            .NotEmpty();
        RuleFor(e=>e.ClientId)
            .NotEmpty();
    }
}

