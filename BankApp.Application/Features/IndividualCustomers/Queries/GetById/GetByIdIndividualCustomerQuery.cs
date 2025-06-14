using AutoMapper;
using BankApp.Application.Features.IndividualCustomers.Rules;
using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Application.Features.IndividualCustomers.Queries.GetById
{
    /// <summary>
    /// ID'ye göre bireysel müşteri getirme sorgusu.
    /// </summary>
    public class GetByIdIndividualCustomerQuery : IRequest<GetByIdIndividualCustomerResponse>, IValidationRequest
    {
        public GetByIdIndividualCustomerRequest Request { get; set; }

        public class GetByIdIndividualCustomerQueryHandler : IRequestHandler<GetByIdIndividualCustomerQuery, GetByIdIndividualCustomerResponse>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;
            private readonly IMapper _mapper;

            public GetByIdIndividualCustomerQueryHandler(IIndividualCustomerRepository individualCustomerRepository, IndividualCustomerBusinessRules individualCustomerBusinessRules, IMapper mapper)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _individualCustomerBusinessRules = individualCustomerBusinessRules;
                _mapper = mapper;
            }

            public async Task<GetByIdIndividualCustomerResponse> Handle(GetByIdIndividualCustomerQuery request, CancellationToken cancellationToken)
            {
                IndividualCustomer? individualCustomer = await _individualCustomerRepository.GetAsync(
                    predicate: x => x.Id == request.Request.Id,
                    include: x => x.Include(x => x.Customer),
                    enableTracking: false,
                    cancellationToken: cancellationToken
                );

                await _individualCustomerBusinessRules.IndividualCustomerShouldExistWhenRequested(individualCustomer);

                GetByIdIndividualCustomerResponse response = _mapper.Map<GetByIdIndividualCustomerResponse>(individualCustomer);
                return response;
            }
        }
    }

    public class GetByIdIndividualCustomerQueryValidator : AbstractValidator<GetByIdIndividualCustomerQuery>
    {
        public GetByIdIndividualCustomerQueryValidator()
        {
            RuleFor(x => x.Request.Id).NotEmpty().WithMessage(Messages.RequiredFields);
        }
    }
} 