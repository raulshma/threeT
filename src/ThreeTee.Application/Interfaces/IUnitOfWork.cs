using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Interfaces;
public interface IUnitOfWork
{
    IGenericRepository<Project> ProjectRepository { get; }
    IGenericRepository<Department> DepartmentRepository { get; }
    IGenericRepository<Designation> DesignationRepository { get; }
    IGenericRepository<BillingType> BillingTypeRepository { get; }

    void Dispose();
    void Save();
    Task<int> SaveAsync();
}