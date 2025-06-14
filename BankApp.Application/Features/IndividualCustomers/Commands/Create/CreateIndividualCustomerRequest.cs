namespace BankApp.Application.Features.IndividualCustomers.Commands.Create
{
    /// <summary>
    /// Bireysel müşteri oluşturma isteği.
    /// </summary>
    public class CreateIndividualCustomerRequest
    {
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
    }
} 