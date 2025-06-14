using BankApp.Core.Repositories;
using BankApp.Domain.Entities;
using BankApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Persistence.Repositories
{
    /// <summary>
    /// CorporateCustomer entity'si için repository implementasyonu.
    /// </summary>
    public class CorporateCustomerRepository : EfRepositoryBase<CorporateCustomer, Guid, BankDbContext>, ICorporateCustomerRepository
    {
        public CorporateCustomerRepository(BankDbContext context) : base(context)
        {
        }

        public async Task<CorporateCustomer?> GetByTaxNumberAsync(string taxNumber, bool includeCustomer = false)
        {
            var query = Query();

            if (includeCustomer)
            {
                query = query.Include(x => x.Customer);
            }

            return await query.FirstOrDefaultAsync(x => x.TaxNumber == taxNumber);
        }

        public async Task<bool> IsTaxNumberUniqueAsync(string taxNumber)
        {
            return !await Query().AnyAsync(x => x.TaxNumber == taxNumber);
        }

        public async Task<IEnumerable<CorporateCustomer>> GetBySectorAsync(string sector)
        {
            return await Query()
                .Include(x => x.Customer)
                .Where(x => x.Sector == sector)
                .ToListAsync();
        }

        public async Task<IEnumerable<CorporateCustomer>> GetByCompanyTypeAsync(string companyType)
        {
            return await Query()
                .Include(x => x.Customer)
                .Where(x => x.CompanyType == companyType)
                .ToListAsync();
        }

        public async Task<IEnumerable<CorporateCustomer>> GetByTaxOfficeAsync(string taxOffice)
        {
            return await Query()
                .Include(x => x.Customer)
                .Where(x => x.TaxOffice == taxOffice)
                .ToListAsync();
        }
    }
} 