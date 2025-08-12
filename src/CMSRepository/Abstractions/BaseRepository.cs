using Infrastructure.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CMSRepository.Abstractions
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public const int MAXMIMUM_RETURN_COUNT = 100;

        protected readonly DbContext dbContext;
        protected readonly DbSet<TEntity> dbSet;



        public BaseRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }



        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }


        public virtual void AddRange(params TEntity[] entities)
        {
            dbSet.AddRange(entities);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }


        public virtual TEntity? Find(params object?[] keyValues)
        {
            return dbSet.Find(keyValues);
        }


        public virtual void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void RemoveRange(params TEntity[] entities)
        {
            dbSet.RemoveRange(entities);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }


        public virtual void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public virtual void UpdateRange(params TEntity[] entities)
        {
            dbSet.UpdateRange(entities);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            dbSet.UpdateRange(entities);
        }



        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await dbSet.AddAsync(entity);

            return result.Entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cs = default)
        {
            var result = await dbSet.AddAsync(entity, cs);

            return result.Entity; 
        }


        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cs = default)
        {
            await dbSet.AddRangeAsync(entities, cs);
        }


        public virtual async Task<TEntity?> FindAsync(params object[] keyValues)
        {
            return await dbSet.FindAsync(keyValues);
        }

        public virtual async Task<TEntity?> FindAsync(object[] keyValues, CancellationToken cs = default)
        {
            return await dbSet.FindAsync(keyValues, cs);
        }


        public virtual async Task<int> SaveChangesAsync(CancellationToken cs = default)
        {
            return await dbContext.SaveChangesAsync(cs);
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }



        public virtual IEnumerable<TEntity> Get(
            Pagination? pagination = null,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            IQueryable<TEntity> query = PreparingGetQuery(pagination, filter, orderBy);

            return query.ToList();
        }


        public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Pagination? pagination = null,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            IQueryable<TEntity> query = PreparingGetQuery(pagination, filter, orderBy);

            return await query.ToListAsync();
        }


        private IQueryable<TEntity> PreparingGetQuery(
            Pagination? pagination,
            Expression<Func<TEntity, bool>>? filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy)
        {
            IQueryable<TEntity> query = dbSet;


            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (pagination != null)
            {
                pagination = ValidatePaginationAndAmendPageNumber(pagination);

                var skippedEntriesCount = (pagination.Number - 1) * pagination.Size;

                query = query.Skip(skippedEntriesCount).Take(pagination.Size);
            }

            return query;
        }
        


        protected static int ValidatePaginationAndAmendPageNumber(int pageNum, int pageSiz)
        {
            return ValidatePaginationAndAmendPageNumber(new Pagination
            {
                Number = pageNum,
                Size = pageSiz,
            }).Number;

        }

        protected static Pagination ValidatePaginationAndAmendPageNumber(Pagination pagination)
        {
            if (pagination.Size < 1)
            {
                throw new InvalidOperationException($"Page size can not be lesser than 1!, The passed page size: {pagination.Size}");
            }

            if (pagination.Number < 0 || pagination.Number > MAXMIMUM_RETURN_COUNT)
            {
                throw new InvalidOperationException($"Page number can be equal or between {0} and {MAXMIMUM_RETURN_COUNT}, The passed page number: {pagination.Number}");
            }
           
            if (pagination.Number == 0)
            {
                pagination.Number = 1;
            }

            return pagination;

        }


    }
}