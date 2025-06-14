namespace BankApp.Application.Features.CorporateCustomers.Queries.GetById
{
    /// <summary>
    /// ID'ye göre kurumsal müşteri getirme sorgusu parametreleri.
    /// </summary>
    public class GetByIdCorporateCustomerRequest
    {
        public Guid Id { get; set; }
    }
} 