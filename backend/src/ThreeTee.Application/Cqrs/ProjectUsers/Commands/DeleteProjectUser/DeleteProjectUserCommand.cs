using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using ThreeTee.Application.Cqrs.ProjectUsers.Commands.UpdateProjectUser;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Cqrs.ProjectUsers.Commands.DeleteProjectUser;

public record DeleteProjectUserCommand : IRequest<string>
{
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
    public Guid? OldProjectId { get; set; }
}

public class DeleteProjectUserCommandHandler : IRequestHandler<DeleteProjectUserCommand, string>
{
    private readonly IEntitiesContext _context;
    public DeleteProjectUserCommandHandler(IEntitiesContext context)
    {
        _context=context;
    }
    public async Task<string> Handle(DeleteProjectUserCommand request, CancellationToken cancellationToken)
    {
        var projectUser = _context.ProjectUsers.FirstOrDefault(p => p.UserId == request.UserId);

        if (projectUser is null)
            return default;

        _context.ProjectUsers.Remove(projectUser);
        await _context.SaveChangesAsync(cancellationToken);
        return "Record Deleted";
    }
}

