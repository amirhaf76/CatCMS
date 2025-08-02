using Microsoft.EntityFrameworkCore;

namespace CMSRepository.Abstractions
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext dbContext;
        protected readonly DbSet<TEntity> dbSet;



        public BaseRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }



        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }


        public void AddRange(params TEntity[] entities)
        {
            dbSet.AddRange(entities);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }


        public TEntity? Find(params object?[] keyValues)
        {
            return dbSet.Find(keyValues);
        }


        public void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(params TEntity[] entities)
        {
            dbSet.RemoveRange(entities);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }


        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public void UpdateRange(params TEntity[] entities)
        {
            dbSet.UpdateRange(entities);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            dbSet.UpdateRange(entities);
        }



        public async Task AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task AddAsync(TEntity entity, CancellationToken cs = default)
        {
            await dbSet.AddAsync(entity, cs);
        }


        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cs = default)
        {
            await dbSet.AddRangeAsync(entities, cs);
        }


        public async Task<TEntity?> FindAsync(params object[] keyValues)
        {
            return await dbSet.FindAsync(keyValues);
        }

        public async Task<TEntity?> FindAsync(object[] keyValues, CancellationToken cs = default)
        {
            return await dbSet.FindAsync(keyValues, cs);
        }


        public async Task<int> SaveChangesAsync(CancellationToken cs = default)
        {
            return await dbContext.SaveChangesAsync(cs);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

    }
}