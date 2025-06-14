using System.Linq.Expressions;
using BankApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BankApp.Core.Repositories
{
    /// <summary>
    /// EntityFramework Core için generic repository implementasyonu.
    /// Tüm entity'ler için temel CRUD operasyonlarını sağlar.
    /// </summary>
    /// <typeparam name="TEntity">Entity tipi</typeparam>
    /// <typeparam name="TId">Entity'nin ID tipi</typeparam>
    /// <typeparam name="TContext">DbContext tipi</typeparam>
    public class EfRepositoryBase<TEntity, TId, TContext> : IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TContext : DbContext
    {
        protected readonly TContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public EfRepositoryBase(TContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Query()
        {
            return DbSet.AsQueryable();
        }

        public async Task<TEntity?> GetAsync(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = DbSet;

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (include != null)
                queryable = include(queryable);

            if (!withDeleted)
                queryable = queryable.Where(x => x.DeletedDate == null);

            return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<IList<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = DbSet;

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (include != null)
                queryable = include(queryable);

            if (!withDeleted)
                queryable = queryable.Where(x => x.DeletedDate == null);

            if (predicate != null)
                queryable = queryable.Where(predicate);

            if (orderBy != null)
                return await orderBy(queryable).ToListAsync(cancellationToken);

            return await queryable.ToListAsync(cancellationToken);
        }

        public async Task<Pagination<TEntity>> GetPaginatedListAsync(
            PaginationRequest request,
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = DbSet;

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (include != null)
                queryable = include(queryable);

            if (!withDeleted)
                queryable = queryable.Where(x => x.DeletedDate == null);

            if (predicate != null)
                queryable = queryable.Where(predicate);

            if (orderBy != null)
                queryable = orderBy(queryable);

            var totalCount = await queryable.CountAsync(cancellationToken);
            var items = await queryable
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync(cancellationToken);

            return new Pagination<TEntity>
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)request.PageSize),
                Items = items
            };
        }

        public async Task<int> CountAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            bool withDeleted = false,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = DbSet;

            if (!withDeleted)
                queryable = queryable.Where(x => x.DeletedDate == null);

            if (predicate != null)
                queryable = queryable.Where(predicate);

            return await queryable.CountAsync(cancellationToken);
        }

        public async Task<bool> AnyAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            bool withDeleted = false,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = DbSet;

            if (!withDeleted)
                queryable = queryable.Where(x => x.DeletedDate == null);

            if (predicate != null)
                queryable = queryable.Where(predicate);

            return await queryable.AnyAsync(cancellationToken);
        }

        public async Task<TEntity> AddAsync(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            await DbSet.AddAsync(entity, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<IList<TEntity>> AddRangeAsync(
            IList<TEntity> entities,
            CancellationToken cancellationToken = default)
        {
            await DbSet.AddRangeAsync(entities, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
            return entities;
        }

        public async Task<TEntity> UpdateAsync(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            DbSet.Update(entity);
            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<IList<TEntity>> UpdateRangeAsync(
            IList<TEntity> entities,
            CancellationToken cancellationToken = default)
        {
            DbSet.UpdateRange(entities);
            await Context.SaveChangesAsync(cancellationToken);
            return entities;
        }

        public async Task<TEntity> DeleteAsync(
            TEntity entity,
            bool permanent = false,
            CancellationToken cancellationToken = default)
        {
            if (permanent)
            {
                DbSet.Remove(entity);
            }
            else
            {
                entity.DeletedDate = DateTime.UtcNow;
                DbSet.Update(entity);
            }

            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<IList<TEntity>> DeleteRangeAsync(
            IList<TEntity> entities,
            bool permanent = false,
            CancellationToken cancellationToken = default)
        {
            if (permanent)
            {
                DbSet.RemoveRange(entities);
            }
            else
            {
                foreach (var entity in entities)
                {
                    entity.DeletedDate = DateTime.UtcNow;
                }
                DbSet.UpdateRange(entities);
            }

            await Context.SaveChangesAsync(cancellationToken);
            return entities;
        }
    }
} 