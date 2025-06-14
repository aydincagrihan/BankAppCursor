using BankApp.Core.Repositories;
using BankApp.Domain.Entities;

namespace BankApp.Application.Services.Repositories
{
    /// <summary>
    /// Customer entity'si için repository arayüzü.
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {
        /// <summary>
        /// Müşteri numarasına göre müşteriyi getirir.
        /// </summary>
        Task<Customer?> GetByCustomerNumberAsync(string customerNumber, bool includeDetails = false);

        /// <summary>
        /// Müşteri numarasının benzersiz olup olmadığını kontrol eder.
        /// </summary>
        Task<bool> IsCustomerNumberUniqueAsync(string customerNumber);

        /// <summary>
        /// Email adresinin benzersiz olup olmadığını kontrol eder.
        /// </summary>
        Task<bool> IsEmailUniqueAsync(string email);

        /// <summary>
        /// Telefon numarasının benzersiz olup olmadığını kontrol eder.
        /// </summary>
        Task<bool> IsPhoneNumberUniqueAsync(string phoneNumber);
    }
} 