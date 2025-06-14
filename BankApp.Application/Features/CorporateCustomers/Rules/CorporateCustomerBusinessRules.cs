using BankApp.Application.Features.CorporateCustomers.Constants;
using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using Core.CrossCuttingConcerns.Exceptions;

namespace BankApp.Application.Features.CorporateCustomers.Rules
{
    /// <summary>
    /// Kurumsal müşteriler için iş kuralları.
    /// </summary>
    public class CorporateCustomerBusinessRules
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly ICustomerRepository _customerRepository;

        public CorporateCustomerBusinessRules(
            ICorporateCustomerRepository corporateCustomerRepository,
            ICustomerRepository customerRepository)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Vergi numarasının benzersiz olup olmadığını kontrol eder.
        /// </summary>
        public async Task TaxNumberShouldBeUnique(string taxNumber)
        {
            var result = await _corporateCustomerRepository.IsTaxNumberUniqueAsync(taxNumber);
            if (!result)
                throw new BusinessException(Messages.CorporateCustomerAlreadyExists);
        }

        /// <summary>
        /// Kurumsal müşterinin var olup olmadığını kontrol eder.
        /// </summary>
        public async Task CorporateCustomerShouldExist(CorporateCustomer? corporateCustomer)
        {
            if (corporateCustomer == null)
                throw new BusinessException(Messages.CorporateCustomerNotFound);
        }

        /// <summary>
        /// Vergi numarasının geçerli olup olmadığını kontrol eder.
        /// </summary>
        public void TaxNumberShouldBeValid(string taxNumber)
        {
            if (string.IsNullOrEmpty(taxNumber) || taxNumber.Length != 10 || !taxNumber.All(char.IsDigit))
                throw new BusinessException(Messages.InvalidTaxNumber);
        }

        /// <summary>
        /// Telefon numarasının geçerli olup olmadığını kontrol eder.
        /// </summary>
        public void PhoneNumberShouldBeValid(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length < 10 || phoneNumber.Length > 15)
                throw new BusinessException(Messages.InvalidPhoneNumber);
        }

        /// <summary>
        /// Email adresinin geçerli olup olmadığını kontrol eder.
        /// </summary>
        public void EmailShouldBeValid(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@") || !email.Contains("."))
                throw new BusinessException(Messages.InvalidEmail);
        }

        /// <summary>
        /// Yıllık gelirin geçerli olup olmadığını kontrol eder.
        /// </summary>
        public void AnnualRevenueShouldBeValid(decimal annualRevenue)
        {
            if (annualRevenue < 0)
                throw new BusinessException(Messages.InvalidAnnualRevenue);
        }

        /// <summary>
        /// Çalışan sayısının geçerli olup olmadığını kontrol eder.
        /// </summary>
        public void NumberOfEmployeesShouldBeValid(int numberOfEmployees)
        {
            if (numberOfEmployees < 0)
                throw new BusinessException(Messages.InvalidNumberOfEmployees);
        }
    }
} 