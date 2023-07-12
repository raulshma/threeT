using Mapster;
using MediatR;
using System.ComponentModel.DataAnnotations;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Cqrs.Projects.Commands.CreateProject;

public record CreateProjectCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; } = DateTime.SpecifyKind(DateTime.Parse("2023-06-04T16:55:44.501Z"), DateTimeKind.Utc);
    public DateTime? EndDate { get; set; }
    public double? BillingPrice { get; set; }
    public required Guid ClientId { get; set; }
}

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
{
    private readonly IEntitiesContext _context;
    public CreateProjectCommandHandler(IEntitiesContext context)
    {
        _context=context;
    }
    public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Project>();
        
        _context.Projects.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}

