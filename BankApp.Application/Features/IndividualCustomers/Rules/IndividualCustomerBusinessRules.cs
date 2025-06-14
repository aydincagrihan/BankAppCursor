using BankApp.Application.Features.IndividualCustomers.Constants;
using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using Core.CrossCuttingConcerns.Exceptions;

namespace BankApp.Application.Features.IndividualCustomers.Rules
{
    /// <summary>
    /// Bireysel müşteriler için iş kuralları.
    /// </summary>
    public class IndividualCustomerBusinessRules
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly ICustomerRepository _customerRepository;

        public IndividualCustomerBusinessRules(
            IIndividualCustomerRepository individualCustomerRepository,
            ICustomerRepository customerRepository)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// TC kimlik numarasının benzersiz olup olmadığını kontrol eder.
        /// </summary>
        public async Task IdentityNumberShouldBeUnique(string identityNumber)
        {
            var result = await _individualCustomerRepository.IsIdentityNumberUniqueAsync(identityNumber);
            if (!result)
                throw new BusinessException(Messages.IndividualCustomerAlreadyExists);
        }

        /// <summary>
        /// Bireysel müşterinin var olup olmadığını kontrol eder.
        /// </summary>
        public async Task IndividualCustomerShouldExist(IndividualCustomer? individualCustomer)
        {
            if (individualCustomer == null)
                throw new BusinessException(Messages.IndividualCustomerNotFound);
        }

        /// <summary>
        /// TC kimlik numarasının geçerli olup olmadığını kontrol eder.
        /// </summary>
        public void IdentityNumberShouldBeValid(string identityNumber)
        {
            if (string.IsNullOrEmpty(identityNumber) || identityNumber.Length != 11 || !identityNumber.All(char.IsDigit))
                throw new BusinessException(Messages.InvalidIdentityNumber);
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
        /// Aylık gelirin geçerli olup olmadığını kontrol eder.
        /// </summary>
        public void MonthlyIncomeShouldBeValid(decimal monthlyIncome)
        {
            if (monthlyIncome < 0)
                throw new BusinessException(Messages.InvalidMonthlyIncome);
        }
    }
} 