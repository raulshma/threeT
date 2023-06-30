using Mapster;
using MapsterMapper;
using MediatR;
using ThreeTee.Application.Mappings;
using ThreeTee.Application.Models;
using ThreeTee.Application.Models.ProjectUser;

namespace ThreeTee.Application.Cqrs.ProjectUsers.Queries;

public record GetProjectUsersWithPaginationQuery : IRequest<PaginatedList<ProjectUserResponse>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetProjectUsersWithPaginationQueryHandler : IRequestHandler<GetProjectUsersWithPaginationQuery, PaginatedList<ProjectUserResponse>>
{
    private readonly IEntitiesContext _context;
    private readonly IMapper _mapper;

    public GetProjectUsersWithPaginationQueryHandler(IEntitiesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProjectUserResponse>> Handle(GetProjectUsersWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.ProjectUsers
            // .OrderBy(pu=>pu.LastTouchedBy)
            .ProjectToType<ProjectUserResponse>()
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}