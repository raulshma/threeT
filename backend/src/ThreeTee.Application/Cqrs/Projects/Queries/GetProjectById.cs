using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreeTee.Application.Models.Projects;

namespace ThreeTee.Application.Cqrs.Projects.Queries;
public record GetProjectByIdQuery : IRequest<ProjectResponse>
{
    public Guid Id { get; set; }
}

public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectResponse>
{
    private readonly IEntitiesContext _context;

    public GetProjectByIdQueryHandler(IEntitiesContext context, IMapper mapper)
    {
        _context = context;
    }
    public async Task<ProjectResponse> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _context.Projects?.ProjectToType<ProjectResponse>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if(project == null)
        { return null; }
        return project;
    }
}

