using Mapster;
using MapsterMapper;
using MediatR;
using ThreeTee.Application.Mappings;
using ThreeTee.Application.Models;
using ThreeTee.Application.Models.ProjectUser;

namespace ThreeTee.Application.Cqrs.ProjectUsers.Queries;

public record GetProjectUsersWithUserIdPaginationQuery : IRequest<PaginatedList<ProjectUserResponse>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public Guid UserId { get; set; }
}

public class GetProjectUsersWithUserIdPaginationQueryHandler : IRequestHandler<GetProjectUsersWithUserIdPaginationQuery, PaginatedList<ProjectUserResponse>>
{
    private readonly IEntitiesContext _context;
    private readonly IMapper _mapper;

    public GetProjectUsersWithUserIdPaginationQueryHandler(IEntitiesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProjectUserResponse>> Handle(GetProjectUsersWithUserIdPaginationQuery request, CancellationToken cancellationToken)
    {
        var projectUser = await _context.ProjectUsers
            .Where(e=>e.UserId==request.UserId)
            // .OrderBy(pu=>pu.LastTouchedBy)
            .ProjectToType<ProjectUserResponse>()
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        if (projectUser != null)
            return projectUser;
        return null;
    }
}