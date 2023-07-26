using FluentValidation;

namespace ThreeTee.Application.Cqrs.Departments.Commands.UpdateDepartment;
public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
{
    public UpdateDepartmentCommandValidator()
    {
        RuleFor(e => e.Name)
            .NotEmpty();
        RuleFor(e => e.Id)
            .NotEmpty();
        RuleFor(e => e.Code)
            .NotEmpty();
    }
}

