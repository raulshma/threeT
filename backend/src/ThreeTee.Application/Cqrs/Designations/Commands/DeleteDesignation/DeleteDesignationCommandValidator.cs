using FluentValidation;
using ThreeTee.Application.Cqrs.Designations.Commands.DeleteDesignation;

namespace ThreeTee.Application.Cqrs.Designations.Commands.DeleteDesignation;
public  class DeleteDesignationCommandValidator:AbstractValidator<DeleteDesignationCommand>
{
    public DeleteDesignationCommandValidator()
    {
        RuleFor(e => e.Id)
            .NotEmpty();
    }
}

