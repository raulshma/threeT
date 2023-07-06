using Mapster;
using MediatR;
using ThreeTee.Application.Mappings;
using ThreeTee.Application.Models;
using ThreeTee.Application.Models.BillingTypes;

namespace ThreeTee.Application.Cqrs.BillingTypes.Queries;
public class GetBillingTypesWithPaginationQuery:IRequest<PaginatedList<BillingTypeResponse>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetBillingTypesWithPaginationQueryHandler : IRequestHandler<GetBillingTypesWithPaginationQuery, PaginatedList<BillingTypeResponse>>
{
    private readonly IEntitiesContext _context;
    public GetBillingTypesWithPaginationQueryHandler(IEntitiesContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<BillingTypeResponse>> Handle(GetBillingTypesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var items = await _context.BillingTypes
           .ProjectToType<BillingTypeResponse>()
           .PaginatedListAsync(request.PageNumber, request.PageSize);
        if (items != null)
            return items;
        return null;
    }
}

