namespace BankApp.Application.Features.IndividualCustomers.Commands.Create
{
    /// <summary>
    /// Bireysel müşteri oluşturma işlemi sonucu.
    /// </summary>
    public class CreatedIndividualCustomerResponse
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
        public string Message { get; set; }
    }
} 