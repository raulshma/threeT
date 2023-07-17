using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreeTee.Application.Models.Clients;

namespace ThreeTee.Application.Cqrs.Clients.Queries;
public record GetClientByIdQuery : IRequest<ClientResponse>
{
    public Guid Id { get; set; }
}

public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ClientResponse>
{
    private readonly IEntitiesContext _context;

    public GetClientByIdQueryHandler(IEntitiesContext context, IMapper mapper)
    {
        _context = context;
    }
    public async Task<ClientResponse> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await _context.Clients?.ProjectToType<ClientResponse>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if(item == null)
        { return null; }
        return item;
    }
}

