using System.Linq.Expressions;
using BankApp.Core.Entities;
using BankApp.Core.Repositories.Pagination;
using Microsoft.EntityFrameworkCore.Query;

namespace BankApp.Core.Repositories
{
    /// <summary>
    /// Generic okuma işlemleri için repository interface'i.
    /// Tüm entity'ler için temel okuma operasyonlarını sağlar.
    /// </summary>
    /// <typeparam name="TEntity">Entity tipi</typeparam>
    /// <typeparam name="TId">Entity'nin ID tipi</typeparam>
    public interface IReadRepository<TEntity, TId> where TEntity : Entity<TId>
    {
        /// <summary>
        /// Entity için IQueryable sorgu kaynağını döndürür.
        /// LINQ sorguları için kullanılır.
        /// </summary>
        IQueryable<TEntity> Query();

        /// <summary>
        /// Verilen koşula göre tek bir entity getirir.
        /// </summary>
        /// <param name="predicate">Filtreleme koşulu</param>
        /// <param name="include">İlişkili verileri yükleme</param>
        /// <param name="withDeleted">Silinmiş kayıtları dahil et</param>
        /// <param name="enableTracking">Change tracking aktif mi?</param>
        /// <param name="cancellationToken">İptal token'ı</param>
        Task<TEntity?> GetAsync(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Verilen koşula göre entity listesi getirir.
        /// </summary>
        /// <param name="predicate">Filtreleme koşulu</param>
        /// <param name="orderBy">Sıralama</param>
        /// <param name="include">İlişkili verileri yükleme</param>
        /// <param name="withDeleted">Silinmiş kayıtları dahil et</param>
        /// <param name="enableTracking">Change tracking aktif mi?</param>
        /// <param name="cancellationToken">İptal token'ı</param>
        Task<IList<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Verilen koşula göre sayfalanmış entity listesi getirir.
        /// </summary>
        /// <param name="request">Sayfalama parametreleri</param>
        /// <param name="predicate">Filtreleme koşulu</param>
        /// <param name="orderBy">Sıralama</param>
        /// <param name="include">İlişkili verileri yükleme</param>
        /// <param name="withDeleted">Silinmiş kayıtları dahil et</param>
        /// <param name="enableTracking">Change tracking aktif mi?</param>
        /// <param name="cancellationToken">İptal token'ı</param>
        Task<PaginationResponse<TEntity>> GetPaginatedListAsync(
            PaginationRequest request,
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Verilen koşula göre kayıt sayısını getirir.
        /// </summary>
        /// <param name="predicate">Filtreleme koşulu</param>
        /// <param name="withDeleted">Silinmiş kayıtları dahil et</param>
        /// <param name="cancellationToken">İptal token'ı</param>
        Task<int> CountAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            bool withDeleted = false,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Verilen koşula göre kayıt var mı kontrol eder.
        /// </summary>
        /// <param name="predicate">Filtreleme koşulu</param>
        /// <param name="withDeleted">Silinmiş kayıtları dahil et</param>
        /// <param name="cancellationToken">İptal token'ı</param>
        Task<bool> AnyAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            bool withDeleted = false,
            CancellationToken cancellationToken = default);
    }
} 