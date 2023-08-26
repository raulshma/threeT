using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ThreeTee.Application.Cqrs.Modules.Commands.DeleteModule;
public class DeleteModuleCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
}

public class DeleteModuleCommandHandler : IRequestHandler<DeleteModuleCommand, Guid>
{
    private readonly IEntitiesContext _context;
    public DeleteModuleCommandHandler(IEntitiesContext context)
    {
        _context = context;
    }
    public async Task<Guid> Handle(DeleteModuleCommand request, CancellationToken cancellationToken)
    {
        var module = await _context.Modules.FirstOrDefaultAsync(e => e.Id == request.Id);
        if (module != null)
        {
            _context.Modules.Remove(module);
            await _context.SaveChangesAsync(cancellationToken);
            return module.Id;
        }
        return Guid.Empty;
    }
}

