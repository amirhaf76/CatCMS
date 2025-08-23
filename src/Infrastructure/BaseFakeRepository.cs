using Infrastructure.GenericRepository;
using System.Linq.Expressions;

namespace Infrastructure
{
    public class BaseFakeRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly List<TEntity> _entities;

        public BaseFakeRepository() : this([])
        {

        }

        public BaseFakeRepository(List<TEntity> entities)
        {
            _entities = entities;
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public Task<TEntity> AddAsync(TEntity entity)
        {
            _entities.Add(entity);

            return Task.FromResult(entity);
        }

        public Task<TEntity> AddAsync(TEntity entity, CancellationToken cs = default)
        {
            _entities.Add(entity);

            return Task.FromResult(entity);
        }

        public void AddRange(params TEntity[] entities)
        {
            _entities.AddRange(entities);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);

            return Task.CompletedTask;
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cs = default)
        {
            _entities.AddRange(entities);

            return Task.CompletedTask;
        }

        public void ApplyPatch(TEntity entity, IDictionary<string, object?> patch)
        {
            throw new NotImplementedException();
        }

        public TEntity? Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> FindAsync(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> FindAsync(object[] keyValues, CancellationToken cs = default)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Get(Pagination? pagination = null, Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAsync(Pagination? pagination = null, Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
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

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
