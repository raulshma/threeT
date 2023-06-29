using FluentValidation;

namespace ThreeTee.Application.Cqrs.ProjectUsers.Commands.DeleteProjectUser;

public class DeleteProjectUserCommandValidator:AbstractValidator<DeleteProjectUserCommand>
{
    public DeleteProjectUserCommandValidator()
    {
        RuleFor(e=>e.UserId)
            .NotEmpty();
        RuleFor(e => e.ProjectId == e.OldProjectId)
            .NotEmpty();
    }
}

