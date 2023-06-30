using MediatR;

namespace ThreeTee.Application.Cqrs.Clients.Commands.DeleteClient;
public class DeleteClientCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}

public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, bool>
{
    private readonly IEntitiesContext _context;
    public DeleteClientCommandHandler(IEntitiesContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var client = _context.Clients.FirstOrDefault(e => e.Id == request.Id);
        if (client is null)
            return false;

        _context.Clients.Remove(client);
        var ret = await _context.SaveChangesAsync(cancellationToken);
        if (ret == 0)
            return false;
        return true;
    }
}

