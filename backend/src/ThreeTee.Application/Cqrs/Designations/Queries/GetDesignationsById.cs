using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreeTee.Application.Models.Designations;

namespace ThreeTee.Application.Cqrs.Designations.Queries;
public class GetDesignationsByIdQuery:IRequest<DesignationResponse>
{
    public Guid Id { get; set; }
}

public class GetDesignationsByIdQueriesHandler : IRequestHandler<GetDesignationsByIdQuery, DesignationResponse>
{
    private readonly IEntitiesContext _context;
    public GetDesignationsByIdQueriesHandler(IEntitiesContext context)
    {
        _context = context;
    }
    public async Task<DesignationResponse> Handle(GetDesignationsByIdQuery request, CancellationToken cancellationToken)
    {
        var designation = await _context.Designations.ProjectToType<DesignationResponse>().FirstOrDefaultAsync(e=>e.Id == request.Id, cancellationToken);
        if(designation== null) { return null; }
        return designation;
    }
}

