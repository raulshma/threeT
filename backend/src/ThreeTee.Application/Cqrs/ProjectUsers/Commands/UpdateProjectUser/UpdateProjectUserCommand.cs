using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Cqrs.ProjectUsers.Commands.UpdateProjectUser;

public record UpdateProjectUserCommand : IRequest<ProjectUser>
{
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
    public Guid? OldProjectId { get; set; }
}

public class UpdateProjectUserCommandHandler : IRequestHandler<UpdateProjectUserCommand, ProjectUser>
{
    private readonly IEntitiesContext _context;
    public UpdateProjectUserCommandHandler(IEntitiesContext context)
    {
        _context = context;
    }
    public async Task<ProjectUser> Handle(UpdateProjectUserCommand request, CancellationToken cancellationToken)
    {
        //Assign new project to User.
        var entity = request.Adapt<ProjectUser>();

        _context.ProjectUsers.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}

