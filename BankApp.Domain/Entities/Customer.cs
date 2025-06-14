using BankApp.Core.Entities;

namespace BankApp.Domain.Entities
{
    public abstract class Customer : Entity<Guid>
    {
        public string CustomerNumber { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public bool IsActive { get; set; }
        public decimal RiskScore { get; set; }
        public DateTime LastTransactionDate { get; set; }
    }

    protected Customer()
    {
        IsActive = true;
    }
} 