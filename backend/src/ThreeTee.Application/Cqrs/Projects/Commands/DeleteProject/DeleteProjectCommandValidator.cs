using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeTee.Application.Cqrs.Projects.Commands.DeleteProject;
public class DeleteProjectCommandValidator:AbstractValidator<DeleteProjectCommand>
{
    public DeleteProjectCommandValidator()
    {
        RuleFor(e => e.Id)
            .NotEmpty();
    }
}
