using Mapster;
using MediatR;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Cqrs.Departments.Commands.UpdateDepartment;
public class UpdateDepartmentCommand : IRequest<Department>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
}

public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, Department>
{
    private readonly IEntitiesContext _context;
    public UpdateDepartmentCommandHandler(IEntitiesContext context)
    {
        _context = context;
    }
    public async Task<Department> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Department>();
        _context.Departments.Update(entity);

        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }
}
