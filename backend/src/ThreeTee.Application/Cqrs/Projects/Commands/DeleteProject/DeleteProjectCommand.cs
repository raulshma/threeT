using MediatR;

namespace ThreeTee.Application.Cqrs.Projects.Commands.DeleteProject;
public class DeleteProjectCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, bool>
{
    private readonly IEntitiesContext _context;
    public DeleteProjectCommandHandler(IEntitiesContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = _context.Projects.FirstOrDefault(e => e.Id == request.Id);
        if (project is null)
            return false;

        _context.Projects.Remove(project);
        var ret = await _context.SaveChangesAsync(cancellationToken);
        if (ret == 0)
            return false;
        return true;
    }
}

