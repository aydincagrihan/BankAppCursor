using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Persistence.EntityConfigurations
{
    /// <summary>
    /// CorporateCustomer entity'si için veritabanı yapılandırması.
    /// </summary>
    public class CorporateCustomerConfiguration : IEntityTypeConfiguration<CorporateCustomer>
    {
        public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
        {
            builder.ToTable("CorporateCustomers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CompanyName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.TaxNumber)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength();

            builder.Property(x => x.TaxOffice)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.CompanyType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Sector)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.AnnualRevenue)
                .HasPrecision(18, 2);

            builder.Property(x => x.NumberOfEmployees)
                .IsRequired();

            builder.Property(x => x.FoundingDate)
                .IsRequired();

            // Customer ile one-to-one ilişki
            builder.HasOne<Customer>()
                .WithOne()
                .HasForeignKey<CorporateCustomer>(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 