using FluentValidation;

namespace ThreeTee.Application.Cqrs.Departments.Commands.DeleteDepartment;
public  class DeleteDesignationCommandValidator:AbstractValidator<DeleteDepartmentCommand>
{
    public DeleteDesignationCommandValidator()
    {
        RuleFor(e => e.Id)
            .NotEmpty();
    }
}

