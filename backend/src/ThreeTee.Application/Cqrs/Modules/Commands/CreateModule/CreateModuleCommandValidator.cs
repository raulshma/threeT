using FluentValidation;
using System;
using System.Collections.Generic;

namespace ThreeTee.Application.Cqrs.Modules.Commands.CreateModule;
public class CreateModuleCommandValidator : AbstractValidator<CreateModuleCommand>
{
    public CreateModuleCommandValidator()
    {
        RuleFor(e => e.Name).NotEmpty();
        RuleFor(e=>e.ProjectId).NotEmpty();
    }
}

