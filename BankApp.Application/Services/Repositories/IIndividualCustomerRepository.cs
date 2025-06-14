using BankApp.Core.Repositories;
using BankApp.Domain.Entities;

namespace BankApp.Application.Services.Repositories
{
    /// <summary>
    /// IndividualCustomer entity'si için repository arayüzü.
    /// </summary>
    public interface IIndividualCustomerRepository : IRepository<IndividualCustomer, Guid>
    {
        /// <summary>
        /// TC kimlik numarasına göre bireysel müşteriyi getirir.
        /// </summary>
        Task<IndividualCustomer?> GetByIdentityNumberAsync(string identityNumber, bool includeCustomer = false);

        /// <summary>
        /// TC kimlik numarasının benzersiz olup olmadığını kontrol eder.
        /// </summary>
        Task<bool> IsIdentityNumberUniqueAsync(string identityNumber);

        /// <summary>
        /// Mesleğe göre bireysel müşterileri getirir.
        /// </summary>
        Task<IEnumerable<IndividualCustomer>> GetByOccupationAsync(string occupation);

        /// <summary>
        /// Medeni duruma göre bireysel müşterileri getirir.
        /// </summary>
        Task<IEnumerable<IndividualCustomer>> GetByMaritalStatusAsync(string maritalStatus);
    }
} 