using BankApp.Core.Repositories;
using BankApp.Domain.Entities;

namespace BankApp.Application.Services.Repositories
{
    /// <summary>
    /// CorporateCustomer entity'si için repository arayüzü.
    /// </summary>
    public interface ICorporateCustomerRepository : IRepository<CorporateCustomer, Guid>
    {
        /// <summary>
        /// Vergi numarasına göre kurumsal müşteriyi getirir.
        /// </summary>
        Task<CorporateCustomer?> GetByTaxNumberAsync(string taxNumber, bool includeCustomer = false);

        /// <summary>
        /// Vergi numarasının benzersiz olup olmadığını kontrol eder.
        /// </summary>
        Task<bool> IsTaxNumberUniqueAsync(string taxNumber);

        /// <summary>
        /// Sektöre göre kurumsal müşterileri getirir.
        /// </summary>
        Task<IEnumerable<CorporateCustomer>> GetBySectorAsync(string sector);

        /// <summary>
        /// Şirket türüne göre kurumsal müşterileri getirir.
        /// </summary>
        Task<IEnumerable<CorporateCustomer>> GetByCompanyTypeAsync(string companyType);

        /// <summary>
        /// Vergi dairesine göre kurumsal müşterileri getirir.
        /// </summary>
        Task<IEnumerable<CorporateCustomer>> GetByTaxOfficeAsync(string taxOffice);
    }
} 