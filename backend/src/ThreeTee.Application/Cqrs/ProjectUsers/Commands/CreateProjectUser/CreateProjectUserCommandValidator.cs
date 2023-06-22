using FluentValidation;
using ThreeTee.Application.Cqrs.ProjectUsers.Commands.CreateProjectUser;

public class CreateProjectUserCommandValidator : AbstractValidator<CreateProjectUserCommand>
{
    public CreateProjectUserCommandValidator()
    {
        RuleFor(v => v.UserId)
            .NotEmpty();
        RuleFor(v => v.ProjectId)
            .NotEmpty();
    }
}