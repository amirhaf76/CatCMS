using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infrastructure.GenericRepository
{

    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity? Find(params object[] keyValues);

        void Add(TEntity entity);

        void Remove(TEntity entity);

        void Update(TEntity entity);

        void RemoveRange(params TEntity[] entities);
        void RemoveRange(IEnumerable<TEntity> entities);

        void AddRange(params TEntity[] entities);
        void AddRange(IEnumerable<TEntity> entities);

        void UpdateRange(params TEntity[] entities);
        void UpdateRange(IEnumerable<TEntity> entities);

        Task<TEntity?> FindAsync(params object[] keyValues);
        Task<TEntity?> FindAsync(object[] keyValues, CancellationToken cs = default);


        Task AddAsync(TEntity entity);
        Task AddAsync(TEntity entity, CancellationToken cs = default);


        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cs = default);


        Task<int> SaveChangesAsync(CancellationToken cs = default);
        Task<int> SaveChangesAsync();

        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "");
        
    }
}