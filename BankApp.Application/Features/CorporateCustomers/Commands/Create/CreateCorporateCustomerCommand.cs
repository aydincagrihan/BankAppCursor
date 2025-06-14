using AutoMapper;
using BankApp.Application.Features.CorporateCustomers.Constants;
using BankApp.Application.Features.CorporateCustomers.Rules;
using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;

namespace BankApp.Application.Features.CorporateCustomers.Commands.Create
{
    /// <summary>
    /// Kurumsal müşteri oluşturma komutu.
    /// </summary>
    public class CreateCorporateCustomerCommand : IRequest<CreateCorporateCustomerResponse>, IValidationRequest
    {
        public CreateCorporateCustomerRequest Request { get; set; }

        public class CreateCorporateCustomerCommandHandler : IRequestHandler<CreateCorporateCustomerCommand, CreateCorporateCustomerResponse>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;
            private readonly IMapper _mapper;

            public CreateCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository, CorporateCustomerBusinessRules corporateCustomerBusinessRules, IMapper mapper)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
                _mapper = mapper;
            }

            public async Task<CreateCorporateCustomerResponse> Handle(CreateCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                await _corporateCustomerBusinessRules.TaxNumberShouldBeUnique(request.Request.TaxNumber);
                await _corporateCustomerBusinessRules.PhoneNumberShouldBeUnique(request.Request.PhoneNumber);
                await _corporateCustomerBusinessRules.EmailShouldBeUnique(request.Request.Email);
                await _corporateCustomerBusinessRules.AnnualRevenueShouldBeGreaterThanZero(request.Request.AnnualRevenue);
                await _corporateCustomerBusinessRules.EmployeeCountShouldBeGreaterThanZero(request.Request.EmployeeCount);

                CorporateCustomer corporateCustomer = _mapper.Map<CorporateCustomer>(request.Request);
                corporateCustomer.Customer = new Customer
                {
                    CustomerNumber = request.Request.CustomerNumber,
                    PhoneNumber = request.Request.PhoneNumber,
                    Email = request.Request.Email,
                    Address = request.Request.Address,
                    RiskScore = request.Request.RiskScore
                };

                CorporateCustomer createdCorporateCustomer = await _corporateCustomerRepository.AddAsync(corporateCustomer);

                CreateCorporateCustomerResponse response = new()
                {
                    Id = createdCorporateCustomer.Id,
                    CustomerNumber = createdCorporateCustomer.Customer.CustomerNumber,
                    CompanyName = createdCorporateCustomer.CompanyName,
                    TaxNumber = createdCorporateCustomer.TaxNumber,
                    Message = Messages.Created
                };

                return response;
            }
        }
    }

    public class CreateCorporateCustomerCommandValidator : AbstractValidator<CreateCorporateCustomerCommand>
    {
        public CreateCorporateCustomerCommandValidator()
        {
            RuleFor(x => x.Request.CompanyName).NotEmpty().WithMessage(Messages.RequiredFields);
            RuleFor(x => x.Request.TaxNumber).NotEmpty().WithMessage(Messages.RequiredFields);
            RuleFor(x => x.Request.TaxOffice).NotEmpty().WithMessage(Messages.RequiredFields);
            RuleFor(x => x.Request.Industry).NotEmpty().WithMessage(Messages.RequiredFields);
            RuleFor(x => x.Request.CustomerNumber).NotEmpty().WithMessage(Messages.RequiredFields);
            RuleFor(x => x.Request.PhoneNumber).NotEmpty().WithMessage(Messages.RequiredFields);
            RuleFor(x => x.Request.Email).NotEmpty().WithMessage(Messages.RequiredFields);
            RuleFor(x => x.Request.Address).NotEmpty().WithMessage(Messages.RequiredFields);
        }
    }
} 