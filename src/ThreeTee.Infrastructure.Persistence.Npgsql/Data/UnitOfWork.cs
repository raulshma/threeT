using ThreeTee.Application.Interfaces;
using ThreeTee.Core.Entities;
using ThreeTee.Infrastructure.Repositories;

namespace ThreeTee.Infrastructure.Persistence.Npgsql.Data;
public class UnitOfWork : IDisposable, IUnitOfWork
{
    private readonly EntitiesContext _context;
    public UnitOfWork(EntitiesContext context) => _context = context;

    private GenericRepository<Project> projectRepository;
    private GenericRepository<Department> departmentRepository;
    private GenericRepository<Designation> designationRepository;
    private GenericRepository<BillingType> billingTypeRepository;

    public IGenericRepository<Project> ProjectRepository
    {
        get
        {
            if (projectRepository == null)
            {
                projectRepository = new GenericRepository<Project>(_context);
            }
            return projectRepository;
        }
    }

    public IGenericRepository<Department> DepartmentRepository
    {
        get
        {
            if (departmentRepository == null)
            {
                departmentRepository = new GenericRepository<Department>(_context);
            }
            return departmentRepository;
        }
    }

    public IGenericRepository<Designation> DesignationRepository
    {
        get
        {
            if (designationRepository == null)
            {
                designationRepository = new GenericRepository<Designation>(_context);
            }
            return designationRepository;
        }
    }

    public IGenericRepository<BillingType> BillingTypeRepository
    {
        get
        {
            if (billingTypeRepository == null)
            {
                billingTypeRepository = new GenericRepository<BillingType>(_context);
            }
            return billingTypeRepository;
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }
    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            _context.Dispose();
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}