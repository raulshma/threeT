using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Interfaces;
public interface IUnitOfWork
{
    IGenericRepository<Project> ProjectRepository { get; }

    void Dispose();
    void Save();
    Task<int> SaveAsync();
}