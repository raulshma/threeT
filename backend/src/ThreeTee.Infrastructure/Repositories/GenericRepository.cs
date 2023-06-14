using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ThreeTee.Application.Interfaces;

namespace ThreeTee.Infrastructure.Repositories;
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    internal DbContext _context;
    internal DbSet<TEntity> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual IEnumerable<TEntity> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "")
    {
        IQueryable<TEntity> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return orderBy(query).ToList();
        }
        else
        {
            return query.ToList();
        }
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
    {
        IQueryable<TEntity> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync();
        }
        else
        {
            return await query.ToListAsync();
        }
    }
    public virtual TEntity GetByID(object id) => _dbSet.Find(id);
    public virtual async Task<TEntity> GetByIDAsync(object id) => await _dbSet.FindAsync(id);

    public virtual void Insert(TEntity entity)
    {
        _dbSet.Add(entity);
    }
    public virtual async Task<TEntity> InsertAsync(TEntity entity)
    {
        var item = await _dbSet.AddAsync(entity);
        return item.Entity;
    }
    public virtual void Delete(object id)
    {
        TEntity entityToDelete = _dbSet.Find(id);
        Delete(entityToDelete);
    }

    public virtual void Delete(TEntity entityToDelete)
    {
        if (_context.Entry(entityToDelete).State == EntityState.Detached)
        {
            _dbSet.Attach(entityToDelete);
        }
        _dbSet.Remove(entityToDelete);
    }

    public virtual void Update(TEntity entityToUpdate)
    {
        _dbSet.Attach(entityToUpdate);
        _context.Entry(entityToUpdate).State = EntityState.Modified;
    }

    public virtual async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public virtual IQueryable<TEntity> AsQueryable(bool tracking = false)
    {
        if (tracking)
            return _dbSet.AsQueryable<TEntity>().AsNoTracking();
        return _dbSet.AsQueryable<TEntity>();
    }

    public virtual int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public async Task<TEntity> UpdateAsync(TEntity entityToUpdate)
    {
        var item = _dbSet.Update(entityToUpdate);
        return item.Entity;
    }
}