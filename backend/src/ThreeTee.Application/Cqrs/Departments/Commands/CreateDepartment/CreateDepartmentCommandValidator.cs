using FluentValidation;

namespace ThreeTee.Application.Cqrs.Departments.Commands.CreateDepartment;
public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentCommandValidator()
    {
        RuleFor(e => e.Name)
            .NotEmpty();
        RuleFor(e => e.Code)
            .NotEmpty();
    }
}

