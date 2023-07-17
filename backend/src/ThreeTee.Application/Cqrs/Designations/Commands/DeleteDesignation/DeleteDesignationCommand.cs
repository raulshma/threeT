using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ThreeTee.Application.Cqrs.Designations.Commands.DeleteDesignation;
public class DeleteDesignationCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
}
public class DeleteDesignationCommandHanlder : IRequestHandler<DeleteDesignationCommand, Guid>
{
    private readonly IEntitiesContext _context;
    public DeleteDesignationCommandHanlder(IEntitiesContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(DeleteDesignationCommand request, CancellationToken cancellationToken)
    {
        var designation = await _context.Designations.FirstOrDefaultAsync(e => e.Id == request.Id);
        if (designation != null)
        {
            _context.Designations.Remove(designation);
            await _context.SaveChangesAsync(cancellationToken);
            return designation.Id;
        }
        return Guid.Empty;
    }
}
