using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreeTee.Application.Models.Departments;

namespace ThreeTee.Application.Cqrs.Departments.Queries;
public class GetDepartmentsByIdQuery : IRequest<DepartmentResponse>
{
    public Guid Id { get; set; }
}

public class GetDepartmentsByIdQueryHandler : IRequestHandler<GetDepartmentsByIdQuery, DepartmentResponse>
{
    private readonly IEntitiesContext _context;
    public GetDepartmentsByIdQueryHandler(IEntitiesContext context)
    {
        _context = context;
    }
    public async Task<DepartmentResponse> Handle(GetDepartmentsByIdQuery request, CancellationToken cancellationToken)
    {
        var department = await _context.Departments.ProjectToType<DepartmentResponse>().FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
        if (department != null)
        {
            //CHECK IT
            var depVal = _context.DepartmentManager.FirstOrDefault(e => e.DepartmentId == request.Id)?.UserId;
            //department.DepartmentManager = _context.ProjectUsers.FirstOrDefault(u=>u.UserId == depVal)?.User.UserName;
            return department;
        }
        return null;
    }
}

