using MediatR;

namespace ThreeTee.Application.Cqrs.ProjectUsers.Commands.DeleteProjectUser;

public record DeleteProjectUserCommand : IRequest<bool>
{
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
}

public class DeleteProjectUserCommandHandler : IRequestHandler<DeleteProjectUserCommand, bool>
{
    private readonly IEntitiesContext _context;
    public DeleteProjectUserCommandHandler(IEntitiesContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(DeleteProjectUserCommand request, CancellationToken cancellationToken)
    {
        var projectUser = _context.ProjectUsers.Where(e => e.UserId == request.UserId)
            .FirstOrDefault(e => e.ProjectId == request.ProjectId);

        if (projectUser is null)
            return false;

        _context.ProjectUsers.Remove(projectUser);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}

