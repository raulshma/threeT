using FluentValidation;

namespace ThreeTee.Application.Cqrs.Clients.Commands.UpdateClient;
public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
{
    public UpdateClientCommandValidator()
    {
        RuleFor(e => e.Id)
              .NotEmpty();
        RuleFor(e => e.Name)
           .NotEmpty();
        RuleFor(e => e.BoardedOn)
            .NotEmpty();
        RuleFor(e => e.BillingTypeId)
        .NotEmpty();
    }
}

