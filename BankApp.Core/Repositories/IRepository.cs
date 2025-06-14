using BankApp.Core.Entities;

namespace BankApp.Core.Repositories
{
    /// <summary>
    /// Generic repository interface'i.
    /// Hem okuma hem yazma operasyonlarını birleştirir.
    /// </summary>
    /// <typeparam name="TEntity">Entity tipi</typeparam>
    /// <typeparam name="TId">Entity'nin ID tipi</typeparam>
    public interface IRepository<TEntity, TId> : IReadRepository<TEntity, TId>, IWriteRepository<TEntity, TId>
        where TEntity : Entity<TId>
    {
    }
} 