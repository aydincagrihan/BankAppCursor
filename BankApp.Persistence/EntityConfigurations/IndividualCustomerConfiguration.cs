using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Persistence.EntityConfigurations
{
    /// <summary>
    /// IndividualCustomer entity'si için veritabanı yapılandırması.
    /// </summary>
    public class IndividualCustomerConfiguration : IEntityTypeConfiguration<IndividualCustomer>
    {
        public void Configure(EntityTypeBuilder<IndividualCustomer> builder)
        {
            builder.ToTable("IndividualCustomers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.IdentityNumber)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength();

            builder.Property(x => x.Gender)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.Occupation)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.MonthlyIncome)
                .HasPrecision(18, 2);

            builder.Property(x => x.MaritalStatus)
                .IsRequired()
                .HasMaxLength(20);

            // Customer ile one-to-one ilişki
            builder.HasOne<Customer>()
                .WithOne()
                .HasForeignKey<IndividualCustomer>(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 