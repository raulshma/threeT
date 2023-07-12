using FluentValidation;

namespace ThreeTee.Application.Cqrs.Clients.Commands.DeleteClient;
public class DeleteClientCommandValidator : AbstractValidator<DeleteClientCommand>
{
    public DeleteClientCommandValidator()
    {
        RuleFor(e => e.Id)
            .NotEmpty();
    }
}
