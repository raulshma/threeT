using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreeTee.Application.Models.Modules;

namespace ThreeTee.Application.Cqrs.Modules.Queries;
public class GetModuleByIdQuery : IRequest<ModuleResponse>
{
    public Guid Id { get; set; }
}

public class GetModuleByIdQueryHandler : IRequestHandler<GetModuleByIdQuery, ModuleResponse>
{
    private readonly IEntitiesContext _context;
    public GetModuleByIdQueryHandler(IEntitiesContext context)
    {
        _context = context;
    }
    public async Task<ModuleResponse> Handle(GetModuleByIdQuery request, CancellationToken cancellationToken)
    {
        var module = await _context.Modules.ProjectToType<ModuleResponse>().FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
        if (module == null) { return null; }
        return module;
    }
}

