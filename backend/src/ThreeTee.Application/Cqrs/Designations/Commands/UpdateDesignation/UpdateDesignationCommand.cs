using Mapster;
using MediatR;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Cqrs.Designations.Commands.UpdateDesignation;
public class UpdateDesignationCommand : IRequest<Designation>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class UpdateDesignationCommandHandler : IRequestHandler<UpdateDesignationCommand, Designation>
{
    private readonly IEntitiesContext _context;
    public UpdateDesignationCommandHandler(IEntitiesContext context)
    {
        _context = context;
    }
    public async Task<Designation> Handle(UpdateDesignationCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Designation>();
        _context.Designations.Update(entity);

        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }
}
