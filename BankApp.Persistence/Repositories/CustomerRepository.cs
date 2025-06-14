using BankApp.Core.Repositories;
using BankApp.Domain.Entities;
using BankApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Persistence.Repositories
{
    /// <summary>
    /// Customer entity'si için repository implementasyonu.
    /// </summary>
    public class CustomerRepository : EfRepositoryBase<Customer, Guid, BankDbContext>, ICustomerRepository
    {
        public CustomerRepository(BankDbContext context) : base(context)
        {
        }

        public async Task<Customer?> GetByCustomerNumberAsync(string customerNumber, bool includeDetails = false)
        {
            var query = Query();

            if (includeDetails)
            {
                query = query.Include(x => x.IndividualCustomer)
                            .Include(x => x.CorporateCustomer);
            }

            return await query.FirstOrDefaultAsync(x => x.CustomerNumber == customerNumber);
        }

        public async Task<bool> IsCustomerNumberUniqueAsync(string customerNumber)
        {
            return !await Query().AnyAsync(x => x.CustomerNumber == customerNumber);
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return !await Query().AnyAsync(x => x.Email == email);
        }

        public async Task<bool> IsPhoneNumberUniqueAsync(string phoneNumber)
        {
            return !await Query().AnyAsync(x => x.PhoneNumber == phoneNumber);
        }
    }
} 