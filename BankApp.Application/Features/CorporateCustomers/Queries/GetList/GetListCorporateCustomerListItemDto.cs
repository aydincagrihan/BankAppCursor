namespace BankApp.Application.Features.CorporateCustomers.Queries.GetList
{
    /// <summary>
    /// Kurumsal müşteri listesi getirme sorgusu sonucu.
    /// </summary>
    public class GetListCorporateCustomerListItemDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public string CompanyType { get; set; }
        public string Sector { get; set; }
        public decimal AnnualRevenue { get; set; }
        public int NumberOfEmployees { get; set; }
        public DateTime FoundingDate { get; set; }
        public string CustomerNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal RiskScore { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
} 