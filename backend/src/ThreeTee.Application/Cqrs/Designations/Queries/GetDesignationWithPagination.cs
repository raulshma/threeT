using Mapster;
using MediatR;
using System;
using ThreeTee.Application.Mappings;
using ThreeTee.Application.Models;
using ThreeTee.Application.Models.Designations;

namespace ThreeTee.Application.Cqrs.Designations.Queries;
public class GetDesignationWithPaginationQuery : IRequest<PaginatedList<DesignationResponse>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetDesignationWithPaginationQueryHandler : IRequestHandler<GetDesignationWithPaginationQuery, PaginatedList<DesignationResponse>>
{
    private readonly IEntitiesContext _context;
    public GetDesignationWithPaginationQueryHandler(IEntitiesContext context)
    {
        _context = context;
    }

    public async  Task<PaginatedList<DesignationResponse>> Handle(GetDesignationWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var designations = await _context.Designations
               // .OrderBy(pu=>pu.LastTouchedBy)
               .ProjectToType<DesignationResponse>()
               .PaginatedListAsync(request.PageNumber, request.PageSize);
        if (designations != null)
            return designations;
        return null;
    }
}

