namespace BankApp.Application.Features.IndividualCustomers.Queries.GetList
{
    /// <summary>
    /// Bireysel müşteri listesi getirme sorgusu sonucu.
    /// </summary>
    public class GetListIndividualCustomerListItemDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public decimal MonthlyIncome { get; set; }
        public string MaritalStatus { get; set; }
        public string CustomerNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal RiskScore { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
} 