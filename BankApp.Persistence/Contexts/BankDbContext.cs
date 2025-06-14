using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Persistence.Contexts
{
    /// <summary>
    /// Banka uygulaması için DbContext sınıfı.
    /// Tüm entity'lerin veritabanı yapılandırmasını ve ilişkilerini yönetir.
    /// </summary>
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
        public DbSet<CorporateCustomer> CorporateCustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Entity konfigürasyonlarını uygula
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Eğer options dışarıdan verilmemişse, varsayılan yapılandırmayı kullan
            if (!optionsBuilder.IsConfigured)
            {
                // Development ortamı için varsayılan connection string
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BankAppDb;Trusted_Connection=True;");
            }
        }
    }
} 