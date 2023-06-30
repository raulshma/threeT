using FluentValidation;

namespace ThreeTee.Application.Cqrs.ProjectUsers.Commands.UpdateProjectUser;

public class UpdateProjectUserCommandValidator:AbstractValidator<UpdateProjectUserCommand>
{
    public UpdateProjectUserCommandValidator()
    {
        RuleFor(v => v.UserId)
            .NotEmpty();
        RuleFor(v => v.ProjectId)
            .NotEmpty();
        RuleFor(v => v.OldProjectId)
            .NotEmpty();
        RuleFor(e => e.ProjectId)
            .NotEqual(v => v.OldProjectId);
    }
}

