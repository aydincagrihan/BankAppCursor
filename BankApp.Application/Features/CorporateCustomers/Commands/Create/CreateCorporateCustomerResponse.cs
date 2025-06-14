namespace BankApp.Application.Features.CorporateCustomers.Commands.Create
{
    /// <summary>
    /// Kurumsal müşteri oluşturma komutu sonucu.
    /// </summary>
    public class CreateCorporateCustomerResponse
    {
        public Guid Id { get; set; }
        public string CustomerNumber { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public string Message { get; set; }
    }
} 