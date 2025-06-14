using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Persistence.EntityConfigurations
{
    /// <summary>
    /// Customer entity'si için veritabanı yapılandırması.
    /// </summary>
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CustomerNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.RiskScore)
                .HasPrecision(5, 2);

            // Soft delete için global query filter
            builder.HasQueryFilter(x => x.DeletedDate == null);

            // CreatedDate için varsayılan değer
            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
} 