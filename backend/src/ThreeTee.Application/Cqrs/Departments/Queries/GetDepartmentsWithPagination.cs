using Mapster;
using MediatR;
using ThreeTee.Application.Mappings;
using ThreeTee.Application.Models;
using ThreeTee.Application.Models.Departments;

namespace ThreeTee.Application.Cqrs.Departments.Queries;
public class GetDepartmentsWithPaginationQuery : IRequest<PaginatedList<DepartmentResponse>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetDepartmentsWithPaginationQueryHandler : IRequestHandler<GetDepartmentsWithPaginationQuery, PaginatedList<DepartmentResponse>>
{
    private readonly IEntitiesContext _context;
    public GetDepartmentsWithPaginationQueryHandler(IEntitiesContext context)
    {
        _context = context;
    }

    public async  Task<PaginatedList<DepartmentResponse>> Handle(GetDepartmentsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var departments = await _context.Departments
               .ProjectToType<DepartmentResponse>()
               .PaginatedListAsync(request.PageNumber, request.PageSize);
        if (departments != null)
            return departments;
        return null;
    }
}

