using FluentValidation;

namespace ThreeTee.Application.Cqrs.Clients.Commands.CreateClient;
public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
{
    public CreateClientCommandValidator()
    {
        RuleFor(e=>e.Name)
            .NotEmpty();
        RuleFor(e=>e.BoardedOn) 
            .NotEmpty();
        RuleFor(e => e.BillingTypeId)
        .NotEmpty();
    }
}

