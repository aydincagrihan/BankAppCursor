using Core.Application.Requests;

namespace BankApp.Application.Features.IndividualCustomers.Queries.GetList
{
    /// <summary>
    /// Bireysel müşteri listesi getirme sorgusu parametreleri.
    /// </summary>
    public class GetListIndividualCustomerRequest : PageRequest
    {
        public string? SearchTerm { get; set; }
        public string? SortBy { get; set; }
        public bool SortDescending { get; set; }
    }
} 