namespace CMSRepository
{

    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Find(params object[] keyValues);

        TEntity Attach(TEntity entity);

        TEntity Add(TEntity entity);

        TEntity Remove(TEntity entity);

        TEntity Update(TEntity entity);


        void AddRange(params TEntity[] entities);

        void AddRange(IEnumerable<TEntity> entities);


        Task<TEntity> FindAsync(params object[] keyValues);
        Task<TEntity> FindAsync(CancellationToken cs = default, params object[] keyValues);

        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cs = default);


        Task AddRangeAsync(params TEntity[] entities);
        Task AddRangeAsync(CancellationToken cs = default, params TEntity[] entities);

        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cs = default);


        Task<int> SaveChangesAsync(CancellationToken cs = default);

        Task<int> SaveChangesAsync();
    }
}