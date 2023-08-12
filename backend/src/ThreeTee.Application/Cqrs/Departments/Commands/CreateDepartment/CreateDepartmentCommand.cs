using Mapster;
using MediatR;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Cqrs.Departments.Commands.CreateDepartment;
public class CreateDepartmentCommand : IRequest<Department>
{
    public string Name { get; set; }
    public string Code { get; set; }
}

public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Department>
{
    private readonly IEntitiesContext _context;
    public CreateDepartmentCommandHandler(IEntitiesContext context)
    {
        _context = context;
    }
    public async Task<Department> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = request.Adapt<Department>();

        _context.Departments.Add(department);
        await _context.SaveChangesAsync(cancellationToken);
        return department;
    }
}

