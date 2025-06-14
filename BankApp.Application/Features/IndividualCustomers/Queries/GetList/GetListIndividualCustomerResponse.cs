using Core.Application.Responses;

namespace BankApp.Application.Features.IndividualCustomers.Queries.GetList
{
    /// <summary>
    /// Bireysel müşteri listesi getirme sorgusu sonucu.
    /// </summary>
    public class GetListIndividualCustomerResponse : IResponse
    {
        public Guid Id { get; set; }
        public string CustomerNumber { get; set; }
        public string FullName { get; set; }
        public string IdentityNumber { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public decimal MonthlyIncome { get; set; }
        public string MaritalStatus { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal RiskScore { get; set; }
        public DateTime CreatedDate { get; set; }
    }
} 