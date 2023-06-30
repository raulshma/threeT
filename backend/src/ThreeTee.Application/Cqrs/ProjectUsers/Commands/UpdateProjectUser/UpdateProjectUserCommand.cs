using FluentValidation;
using Mapster;
using MediatR;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Cqrs.ProjectUsers.Commands.UpdateProjectUser;

public record UpdateProjectUserCommand : IRequest<ProjectUser>
{
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
    public Guid OldProjectId { get; set; }
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
        //Check user for project present. If not create new one.

        var projectUser = _context.ProjectUsers.Where(e => e.UserId == request.UserId)
            .FirstOrDefault(e => e.ProjectId == request.ProjectId);
        if (projectUser == null)
        {
            var entity = request.Adapt<ProjectUser>();

            _context.ProjectUsers.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
        return projectUser;
    }
}

