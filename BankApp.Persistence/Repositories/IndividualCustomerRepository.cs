using BankApp.Core.Repositories;
using BankApp.Domain.Entities;
using BankApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Persistence.Repositories
{
    /// <summary>
    /// IndividualCustomer entity'si için repository implementasyonu.
    /// </summary>
    public class IndividualCustomerRepository : EfRepositoryBase<IndividualCustomer, Guid, BankDbContext>, IIndividualCustomerRepository
    {
        public IndividualCustomerRepository(BankDbContext context) : base(context)
        {
        }

        public async Task<IndividualCustomer?> GetByIdentityNumberAsync(string identityNumber, bool includeCustomer = false)
        {
            var query = Query();

            if (includeCustomer)
            {
                query = query.Include(x => x.Customer);
            }

            return await query.FirstOrDefaultAsync(x => x.IdentityNumber == identityNumber);
        }

        public async Task<bool> IsIdentityNumberUniqueAsync(string identityNumber)
        {
            return !await Query().AnyAsync(x => x.IdentityNumber == identityNumber);
        }

        public async Task<IEnumerable<IndividualCustomer>> GetByOccupationAsync(string occupation)
        {
            return await Query()
                .Include(x => x.Customer)
                .Where(x => x.Occupation == occupation)
                .ToListAsync();
        }

        public async Task<IEnumerable<IndividualCustomer>> GetByMaritalStatusAsync(string maritalStatus)
        {
            return await Query()
                .Include(x => x.Customer)
                .Where(x => x.MaritalStatus == maritalStatus)
                .ToListAsync();
        }
    }
} 