namespace BankApp.Application.Features.IndividualCustomers.Queries.GetById
{
    /// <summary>
    /// ID'ye göre bireysel müşteri getirme isteği.
    /// </summary>
    public class GetByIdIndividualCustomerRequest
    {
        public Guid Id { get; set; }
    }
} 