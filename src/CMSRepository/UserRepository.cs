namespace CMSRepository
{
    public class UserRepository : BaseRepository<User>
    {

    }

    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public TEntity Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> AddAsync(TEntity entity, CancellationToken cs = default)
        {
            throw new NotImplementedException();
        }

        public void AddRange(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(CancellationToken cs = default, params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cs = default)
        {
            throw new NotImplementedException();
        }

        public TEntity Attach(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// <exception cref="EntityNotFoundException"></exception>
        public TEntity Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindAsync(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindAsync(CancellationToken cs = default, params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public TEntity Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken cs = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}