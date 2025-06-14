using AutoMapper;
using BankApp.Application.Features.CorporateCustomers.Rules;
using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Application.Features.CorporateCustomers.Queries.GetById
{
    /// <summary>
    /// ID'ye göre kurumsal müşteri getirme sorgusu.
    /// </summary>
    public class GetByIdCorporateCustomerQuery : IRequest<GetByIdCorporateCustomerResponse>, IValidationRequest
    {
        public GetByIdCorporateCustomerRequest Request { get; set; }

        public class GetByIdCorporateCustomerQueryHandler : IRequestHandler<GetByIdCorporateCustomerQuery, GetByIdCorporateCustomerResponse>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;
            private readonly IMapper _mapper;

            public GetByIdCorporateCustomerQueryHandler(ICorporateCustomerRepository corporateCustomerRepository, CorporateCustomerBusinessRules corporateCustomerBusinessRules, IMapper mapper)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
                _mapper = mapper;
            }

            public async Task<GetByIdCorporateCustomerResponse> Handle(GetByIdCorporateCustomerQuery request, CancellationToken cancellationToken)
            {
                CorporateCustomer? corporateCustomer = await _corporateCustomerRepository.GetAsync(
                    predicate: x => x.Id == request.Request.Id,
                    include: x => x.Include(x => x.Customer),
                    enableTracking: false,
                    cancellationToken: cancellationToken
                );

                await _corporateCustomerBusinessRules.CorporateCustomerShouldExistWhenRequested(corporateCustomer);

                GetByIdCorporateCustomerResponse response = _mapper.Map<GetByIdCorporateCustomerResponse>(corporateCustomer);
                return response;
            }
        }
    }

    public class GetByIdCorporateCustomerQueryValidator : AbstractValidator<GetByIdCorporateCustomerQuery>
    {
        public GetByIdCorporateCustomerQueryValidator()
        {
            RuleFor(x => x.Request.Id).NotEmpty();
        }
    }
} 