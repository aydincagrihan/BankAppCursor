namespace BankApp.Application.Features.IndividualCustomers.Queries.GetById
{
    /// <summary>
    /// ID'ye göre bireysel müşteri getirme sorgusu sonucu.
    /// </summary>
    public class GetByIdIndividualCustomerResponse
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
        public string Address { get; set; }
        public decimal RiskScore { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
} 