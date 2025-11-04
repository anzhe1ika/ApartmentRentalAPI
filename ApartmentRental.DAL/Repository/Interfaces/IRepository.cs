using System.Collections;
using System.Linq.Expressions;

namespace ApartmentRental.DAL.Repository.Interfaces
{
    public interface IRepository<TEntity> : IQueryable<TEntity>, IEnumerable<TEntity>, IEnumerable, IQueryable, IAsyncEnumerable<TEntity>
        where TEntity : class
    {
        Task<int> BatchDeleteAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> BatchUpdateAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> updateFactory);

        Task<TEntity> AddAsync(TEntity entity);

        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        Task<TEntity> FindAsync(object[] keyValues);

        TEntity Update(TEntity entity);

        IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities);

        IQueryable<TEntity> FromSqlInterpolated(FormattableString sql);
        Task<int> SaveChangesAsync();
    }
}
