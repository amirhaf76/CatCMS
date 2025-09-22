using SharedKernel;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace CMS.Infrastructure
{
    public class BaseFakeRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly Dictionary<object[], TEntity> _entities;
        private readonly Func<TEntity, object[]> _getKey;

        private int _tracker;

        public BaseFakeRepository(Func<TEntity, object[]> getKey) : this([], getKey)
        {
        }

        public BaseFakeRepository(Dictionary<object[], TEntity> entities, Func<TEntity, object[]> getKey)
        {
            _entities = new Dictionary<object[], TEntity>(entities, new BaseFakeIEqualityComparer());
            _getKey = getKey;
        }

        public void Add(TEntity entity)
        {
            AddAndChangeTracker(entity);
        }

        private void AddAndChangeTracker(TEntity entity)
        {
            _entities.Add(_getKey(entity), entity);

            _tracker++;
        }

        public Task<TEntity> AddAsync(TEntity entity)
        {
            AddAndChangeTracker(entity);

            return Task.FromResult(entity);
        }

        public Task<TEntity> AddAsync(TEntity entity, CancellationToken cs = default)
        {
            AddAndChangeTracker(entity);

            return Task.FromResult(entity);
        }

        public void AddRange(params TEntity[] entities)
        {
            foreach (var entity in entities)
            {
                AddAndChangeTracker(entity);
            }
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                AddAndChangeTracker(entity);
            }
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                AddAndChangeTracker(entity);
            }

            return Task.CompletedTask;
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cs = default)
        {
            foreach (var entity in entities)
            {
                AddAndChangeTracker(entity);
            }

            return Task.CompletedTask;
        }

        public void ApplyPatch(TEntity entity, IDictionary<string, object?> patch)
        {
            throw new NotImplementedException();
        }

        public TEntity? Find(params object[] keyValues)
        {
            return _entities.GetValueOrDefault(keyValues);
        }

        public Task<TEntity?> FindAsync(params object[] keyValues)
        {
            return Task.FromResult(_entities.GetValueOrDefault(keyValues));
        }

        public Task<TEntity?> FindAsync(object[] keyValues, CancellationToken cs = default)
        {
            return Task.FromResult(_entities.GetValueOrDefault(keyValues));
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
            RemoveAndChangeTracker(entity);
        }

        private void RemoveAndChangeTracker(TEntity entity)
        {
            _entities.Remove(_getKey(entity));

            _tracker++;
        }

        public void RemoveRange(params TEntity[] entities)
        {
            foreach (var entity in entities)
            {
                RemoveAndChangeTracker(entity);
            }
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                RemoveAndChangeTracker(entity);
            }
        }

        public Task<int> SaveChangesAsync(CancellationToken cs = default)
        {
            int currentTracker = _tracker;

            _tracker = 0;

            return Task.FromResult(currentTracker);
        }

        public Task<int> SaveChangesAsync()
        {
            int currentTracker = _tracker;

            _tracker = 0;

            return Task.FromResult(currentTracker);
        }

        public void Update(TEntity entity)
        {
            UpdateAndChangeTracker(entity);
        }

        private void UpdateAndChangeTracker(TEntity entity)
        {
            var theKey = _getKey(entity);

            if (_entities.ContainsKey(theKey))
            {
                _entities[theKey] = entity;

                _tracker++;
            }
        }

        public void UpdateRange(params TEntity[] entities)
        {
            foreach (var entity in entities)
            {
                UpdateAndChangeTracker(entity);
            }
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                UpdateAndChangeTracker(entity);
            }
        }

        private class BaseFakeIEqualityComparer : IEqualityComparer<object[]>
        {
            public bool Equals(object[]? x, object[]? y)
            {
                if (x == null || y == null) return false;

                if (x.Length != y.Length) return false;

                for (int index = 0; index < y.Length; ++index)
                {
                    if (x[index] != y[index]) return false;
                }

                return true;
            }

            public int GetHashCode([DisallowNull] object[] obj)
            {
                return HashCode.Combine(obj);
            }
        }
    }
}
