namespace BankApp.Application.Features.CorporateCustomers.Commands.Create
{
    /// <summary>
    /// Kurumsal müşteri oluşturma komutu parametreleri.
    /// </summary>
    public class CreateCorporateCustomerRequest
    {
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public string Industry { get; set; }
        public decimal AnnualRevenue { get; set; }
        public int EmployeeCount { get; set; }
        public string CustomerNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal RiskScore { get; set; }
    }
} 