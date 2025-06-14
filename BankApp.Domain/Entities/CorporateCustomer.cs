using BankApp.Core.Entities;

namespace BankApp.Domain.Entities
{
    public class CorporateCustomer : Customer
    {
        public string CompanyName { get; set; } = null!;
        public string TaxNumber { get; set; } = null!;
        public string TaxOffice { get; set; } = null!;
        public string CompanyType { get; set; } = null!; // Limited, Anonim, vb.
        public string Sector { get; set; } = null!;
        public decimal AnnualTurnover { get; set; }
        public int EmployeeCount { get; set; }
        public string AuthorizedPerson { get; set; } = null!;
        public string AuthorizedPersonTitle { get; set; } = null!;
        public string AuthorizedPersonPhone { get; set; } = null!;
    }
} 