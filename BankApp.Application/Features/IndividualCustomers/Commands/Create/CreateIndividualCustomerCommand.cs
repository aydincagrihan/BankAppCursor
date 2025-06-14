using BankApp.Application.Features.IndividualCustomers.Constants;
using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Commands.Create
{
    /// <summary>
    /// Bireysel müşteri oluşturma komutu.
    /// </summary>
    public class CreateIndividualCustomerCommand : IRequest<CreateIndividualCustomerResponse>, IValidationRequest
    {
        public CreateIndividualCustomerRequest Request { get; set; }

        public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, CreateIndividualCustomerResponse>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly ICustomerRepository _customerRepository;
            private readonly IndividualCustomerBusinessRules _businessRules;
            private readonly IMapper _mapper;

            public CreateIndividualCustomerCommandHandler(
                IIndividualCustomerRepository individualCustomerRepository,
                ICustomerRepository customerRepository,
                IndividualCustomerBusinessRules businessRules,
                IMapper mapper)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _customerRepository = customerRepository;
                _businessRules = businessRules;
                _mapper = mapper;
            }

            public async Task<CreateIndividualCustomerResponse> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                // İş kurallarını kontrol et
                await _businessRules.IdentityNumberShouldBeUnique(request.Request.IdentityNumber);
                _businessRules.IdentityNumberShouldBeValid(request.Request.IdentityNumber);
                _businessRules.PhoneNumberShouldBeValid(request.Request.PhoneNumber);
                _businessRules.EmailShouldBeValid(request.Request.Email);
                _businessRules.MonthlyIncomeShouldBeValid(request.Request.MonthlyIncome);

                // Customer oluştur
                var customer = _mapper.Map<Customer>(request.Request);
                await _customerRepository.AddAsync(customer);

                // IndividualCustomer oluştur
                var individualCustomer = _mapper.Map<IndividualCustomer>(request.Request);
                individualCustomer.Id = customer.Id;
                await _individualCustomerRepository.AddAsync(individualCustomer);

                // Response oluştur
                var response = new CreateIndividualCustomerResponse
                {
                    Id = individualCustomer.Id,
                    CustomerNumber = customer.CustomerNumber,
                    FullName = $"{individualCustomer.FirstName} {individualCustomer.LastName}",
                    IdentityNumber = individualCustomer.IdentityNumber,
                    Message = Messages.IndividualCustomerCreated
                };

                return response;
            }
        }
    }

    public class CreateIndividualCustomerCommandValidator : AbstractValidator<CreateIndividualCustomerCommand>
    {
        public CreateIndividualCustomerCommandValidator()
        {
            RuleFor(x => x.Request.FirstName).NotEmpty().WithMessage(Messages.RequiredFields);
            RuleFor(x => x.Request.LastName).NotEmpty().WithMessage(Messages.RequiredFields);
            RuleFor(x => x.Request.IdentityNumber).NotEmpty().WithMessage(Messages.RequiredFields);
            RuleFor(x => x.Request.Gender).NotEmpty().WithMessage(Messages.RequiredFields);
            RuleFor(x => x.Request.Occupation).NotEmpty().WithMessage(Messages.RequiredFields);
            RuleFor(x => x.Request.MaritalStatus).NotEmpty().WithMessage(Messages.RequiredFields);
            RuleFor(x => x.Request.CustomerNumber).NotEmpty().WithMessage(Messages.RequiredFields);
            RuleFor(x => x.Request.PhoneNumber).NotEmpty().WithMessage(Messages.RequiredFields);
            RuleFor(x => x.Request.Email).NotEmpty().WithMessage(Messages.RequiredFields);
            RuleFor(x => x.Request.Address).NotEmpty().WithMessage(Messages.RequiredFields);
        }
    }
} 