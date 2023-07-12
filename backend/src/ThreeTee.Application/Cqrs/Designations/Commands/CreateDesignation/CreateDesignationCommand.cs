using Mapster;
using MediatR;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Cqrs.Designations.Commands.CreateDesignation;
public class CreateDesignationCommand : IRequest<Designation>
{
    public string Name { get; set; }
}

public class CreateDesignationCommandHandler : IRequestHandler<CreateDesignationCommand, Designation>
{
    private readonly IEntitiesContext _context;
    public CreateDesignationCommandHandler(IEntitiesContext context)
    {
        _context = context;
    }
    public async Task<Designation> Handle(CreateDesignationCommand request, CancellationToken cancellationToken)
    {
        var designation = request.Adapt<Designation>();

        _context.Designations.Add(designation);
        await _context.SaveChangesAsync(cancellationToken);
        return designation;
    }
}

