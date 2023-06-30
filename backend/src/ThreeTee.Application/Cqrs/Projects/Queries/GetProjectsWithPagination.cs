using Mapster;
using MediatR;
using ThreeTee.Application.Mappings;
using ThreeTee.Application.Models;
using ThreeTee.Application.Models.Projects;

namespace ThreeTee.Application.Cqrs.Projects.Queries;

public record GetProjectsWithPaginationQuery : IRequest<PaginatedList<ProjectResponse>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetProjectsWithPaginationQueryHandler : IRequestHandler<GetProjectsWithPaginationQuery, PaginatedList<ProjectResponse>>
{
    private readonly IEntitiesContext _context;
    public GetProjectsWithPaginationQueryHandler(IEntitiesContext context)
    {
        _context = context;
    }
    async Task<PaginatedList<ProjectResponse>> IRequestHandler<GetProjectsWithPaginationQuery, PaginatedList<ProjectResponse>>.Handle(GetProjectsWithPaginationQuery request, CancellationToken cancellationToken)
    {

        var projects = await _context.Projects
            // .OrderBy(pu=>pu.LastTouchedBy)
            .ProjectToType<ProjectResponse>()
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        if (projects != null)
            return projects;
        return null;
    }
}

