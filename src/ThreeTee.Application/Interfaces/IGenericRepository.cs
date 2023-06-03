using System.Linq.Expressions;

namespace ThreeTee.Application.Interfaces;
public interface IGenericRepository<TEntity> where TEntity : class
{
    void Delete(object id);
    void Delete(TEntity entityToDelete);
    IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
    Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
    TEntity GetByID(object id);
    void Insert(TEntity entity);
    Task<TEntity> InsertAsync(TEntity entity);
    void Update(TEntity entityToUpdate);

    Task<int> SaveChangesAsync();
    int SaveChanges();
}