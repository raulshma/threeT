using Mapster;
using MediatR;
using ThreeTee.Application.Mappings;
using ThreeTee.Application.Models;
using ThreeTee.Application.Models.Modules;

namespace ThreeTee.Application.Cqrs.Modules.Queries;
public class GetModuleWithPagination : IRequest<PaginatedList<ModuleResponse>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetModuleWithpaginationHandler : IRequestHandler<GetModuleWithPagination, PaginatedList<ModuleResponse>>
{
    private readonly IEntitiesContext _context;
    public GetModuleWithpaginationHandler(IEntitiesContext context)
    {
        _context = context;
    }
    public async Task<PaginatedList<ModuleResponse>> Handle(GetModuleWithPagination request, CancellationToken cancellationToken)
    {
        var modules = await _context.Modules
               .ProjectToType<ModuleResponse>()
               .PaginatedListAsync(request.PageNumber, request.PageSize);
        if (modules != null)
            return modules;
        return null;
    }
}
