using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ThreeTee.Application.Cqrs.Departments.Commands.DeleteDepartment;
public class DeleteDepartmentCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
}
public class DeleteDepartmentCommandHanlder : IRequestHandler<DeleteDepartmentCommand, Guid>
{
    private readonly IEntitiesContext _context;
    public DeleteDepartmentCommandHanlder(IEntitiesContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await _context.Departments.FirstOrDefaultAsync(e => e.Id == request.Id);
        if (department != null)
        {
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync(cancellationToken);
            return department.Id;
        }
        return Guid.Empty;
    }
}
