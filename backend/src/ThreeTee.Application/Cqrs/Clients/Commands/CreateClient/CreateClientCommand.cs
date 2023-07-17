using Mapster;
using MediatR;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Cqrs.Clients.Commands.CreateClient;

public record CreateClientCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public DateTime BoardedOn { get; set; } = DateTime.SpecifyKind(DateTime.Parse("2023-06-04T16:55:44.501Z"), DateTimeKind.Utc);
    public Guid BoardedById { get; set; }
    public string? Country { get; set; }
    public bool IsActive { get; set; }
    public Guid BillingTypeId { get; set; }
}

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Guid>
{
    private readonly IEntitiesContext _context;
    public CreateClientCommandHandler(IEntitiesContext context)
    {
        _context=context;
    }
    public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Client>();
        
        _context.Clients.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}

