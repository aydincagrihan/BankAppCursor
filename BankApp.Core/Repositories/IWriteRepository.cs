using BankApp.Core.Entities;

namespace BankApp.Core.Repositories
{
    /// <summary>
    /// Generic yazma işlemleri için repository interface'i.
    /// Tüm entity'ler için temel yazma operasyonlarını sağlar.
    /// </summary>
    /// <typeparam name="TEntity">Entity tipi</typeparam>
    /// <typeparam name="TId">Entity'nin ID tipi</typeparam>
    public interface IWriteRepository<TEntity, TId> where TEntity : Entity<TId>
    {
        /// <summary>
        /// Yeni bir entity ekler.
        /// </summary>
        /// <param name="entity">Eklenecek entity</param>
        /// <param name="cancellationToken">İptal token'ı</param>
        Task<TEntity> AddAsync(
            TEntity entity,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Birden fazla entity ekler.
        /// </summary>
        /// <param name="entities">Eklenecek entity'ler</param>
        /// <param name="cancellationToken">İptal token'ı</param>
        Task<IList<TEntity>> AddRangeAsync(
            IList<TEntity> entities,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Mevcut bir entity'yi günceller.
        /// </summary>
        /// <param name="entity">Güncellenecek entity</param>
        /// <param name="cancellationToken">İptal token'ı</param>
        Task<TEntity> UpdateAsync(
            TEntity entity,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Birden fazla entity'yi günceller.
        /// </summary>
        /// <param name="entities">Güncellenecek entity'ler</param>
        /// <param name="cancellationToken">İptal token'ı</param>
        Task<IList<TEntity>> UpdateRangeAsync(
            IList<TEntity> entities,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Bir entity'yi siler.
        /// </summary>
        /// <param name="entity">Silinecek entity</param>
        /// <param name="permanent">Kalıcı silme mi?</param>
        /// <param name="cancellationToken">İptal token'ı</param>
        Task<TEntity> DeleteAsync(
            TEntity entity,
            bool permanent = false,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Birden fazla entity'yi siler.
        /// </summary>
        /// <param name="entities">Silinecek entity'ler</param>
        /// <param name="permanent">Kalıcı silme mi?</param>
        /// <param name="cancellationToken">İptal token'ı</param>
        Task<IList<TEntity>> DeleteRangeAsync(
            IList<TEntity> entities,
            bool permanent = false,
            CancellationToken cancellationToken = default);
    }
} 