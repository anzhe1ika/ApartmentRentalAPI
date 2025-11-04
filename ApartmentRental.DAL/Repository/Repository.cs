using ApartmentRental.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;
using Z.EntityFramework.Plus;

namespace ApartmentRental.DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>, IQueryable<TEntity>, IEnumerable<TEntity>, IEnumerable, IQueryable, IAsyncEnumerable<TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public Type ElementType => ((IQueryable)_dbSet).ElementType;

        public Expression Expression => ((IQueryable)_dbSet).Expression;

        public IQueryProvider Provider => ((IQueryable)_dbSet).Provider;

        public async Task<int> BatchDeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Queryable.Where(_dbSet, predicate).DeleteAsync();
        }

        public async Task<int> BatchUpdateAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> updateFactory)
        {
            return await Queryable.Where(_dbSet, predicate).UpdateAsync(updateFactory);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            TEntity[] entitiesArray = (entities as TEntity[]) ?? entities.ToArray();
            await _dbSet.AddRangeAsync(entitiesArray);
            return entitiesArray;
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<TEntity> FindAsync(object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues);
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities)
        {
            TEntity[] array = (entities as TEntity[]) ?? entities.ToArray();
            _dbSet.UpdateRange(array);
            return array;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return ((IEnumerable<TEntity>)_dbSet).GetEnumerator();
        }

        public IAsyncEnumerator<TEntity> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
        {
            return ((IAsyncEnumerable<TEntity>)_dbSet).GetAsyncEnumerator(cancellationToken);
        }

        public IQueryable<TEntity> FromSqlInterpolated(FormattableString sql)
        {
            return _dbSet.FromSqlInterpolated(sql);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
