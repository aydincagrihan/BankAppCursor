using BankApp.Core.Entities;

namespace BankApp.Domain.Entities
{
    public class IndividualCustomer : Customer
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string IdentityNumber { get; set; } = null!; // TC Kimlik No
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string Occupation { get; set; } = null!;
        public decimal MonthlyIncome { get; set; }
        public string MaritalStatus { get; set; } = null!;
    }
} 