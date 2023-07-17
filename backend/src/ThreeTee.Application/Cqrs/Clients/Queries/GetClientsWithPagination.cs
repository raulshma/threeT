using Mapster;
using MediatR;
using ThreeTee.Application.Mappings;
using ThreeTee.Application.Models;
using ThreeTee.Application.Models.Clients;
using ThreeTee.Application.Models.Projects;

namespace ThreeTee.Application.Cqrs.Clients.Queries;

public record GetClientsWithPaginationQuery : IRequest<PaginatedList<ClientResponse>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetClientsWithPaginationQueryHandler : IRequestHandler<GetClientsWithPaginationQuery, PaginatedList<ClientResponse>>
{
    private readonly IEntitiesContext _context;
    public GetClientsWithPaginationQueryHandler(IEntitiesContext context)
    {
        _context = context;
    }
    async Task<PaginatedList<ClientResponse>> IRequestHandler<GetClientsWithPaginationQuery, PaginatedList<ClientResponse>>.Handle(GetClientsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var items = await _context.Clients
    // .OrderBy(pu=>pu.LastTouchedBy)
    .ProjectToType<ClientResponse>()
    .PaginatedListAsync(request.PageNumber, request.PageSize);
        if (items != null)
            return items;
        return null;
    }
}

