namespace BankApp.Application.Features.IndividualCustomers.Commands.Create
{
    /// <summary>
    /// Bireysel müşteri oluşturma işlemi sonucu.
    /// </summary>
    public class CreateIndividualCustomerResponse
    {
        public Guid Id { get; set; }
        public string CustomerNumber { get; set; }
        public string FullName { get; set; }
        public string IdentityNumber { get; set; }
        public string Message { get; set; }
    }
} 