using Mapster;
using MediatR;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Cqrs.Clients.Commands.UpdateClient;
public record class UpdateClientCommand : IRequest<Client>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime BoardedOn { get; set; }
    public Guid BoardedById { get; set; }
    public string? Country { get; set; }
    public bool IsActive { get; set; }
    public Guid BillingTypeId { get; set; }
}

public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Client>
{
    private readonly IEntitiesContext _context;
    public UpdateClientCommandHandler(IEntitiesContext context)
    {
        _context = context;
    }
    public async Task<Client> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Client>();
        _context.Clients.Update(entity);

        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }
}

