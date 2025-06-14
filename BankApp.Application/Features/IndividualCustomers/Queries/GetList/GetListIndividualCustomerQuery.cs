using AutoMapper;
using BankApp.Application.Features.IndividualCustomers.Constants;
using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using Core.Application.Pipelines.Validation;
using Core.Application.Requests;
using Core.Persistence.Paging;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Application.Features.IndividualCustomers.Queries.GetList
{
    /// <summary>
    /// Bireysel müşteri listesi getirme sorgusu.
    /// </summary>
    public class GetListIndividualCustomerQuery : IRequest<GetListResponse<GetListIndividualCustomerResponse>>, IValidationRequest
    {
        public GetListIndividualCustomerRequest Request { get; set; }

        public class GetListIndividualCustomerQueryHandler : IRequestHandler<GetListIndividualCustomerQuery, GetListResponse<GetListIndividualCustomerResponse>>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly IMapper _mapper;

            public GetListIndividualCustomerQueryHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListIndividualCustomerResponse>> Handle(GetListIndividualCustomerQuery request, CancellationToken cancellationToken)
            {
                IPaginate<IndividualCustomer> individualCustomers = await _individualCustomerRepository.GetListAsync(
                    predicate: x => string.IsNullOrEmpty(request.Request.SearchTerm) || 
                        x.Customer.CustomerNumber.Contains(request.Request.SearchTerm) ||
                        x.Customer.PhoneNumber.Contains(request.Request.SearchTerm) ||
                        x.Customer.Email.Contains(request.Request.SearchTerm) ||
                        x.FirstName.Contains(request.Request.SearchTerm) ||
                        x.LastName.Contains(request.Request.SearchTerm) ||
                        x.IdentityNumber.Contains(request.Request.SearchTerm),
                    include: x => x.Include(x => x.Customer),
                    orderBy: x => string.IsNullOrEmpty(request.Request.SortBy) ? 
                        x.OrderByDescending(x => x.CreatedDate) :
                        request.Request.SortBy switch
                        {
                            "customerNumber" => request.Request.SortDescending ? 
                                x.OrderByDescending(x => x.Customer.CustomerNumber) : 
                                x.OrderBy(x => x.Customer.CustomerNumber),
                            "fullName" => request.Request.SortDescending ? 
                                x.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName) : 
                                x.OrderBy(x => x.FirstName).ThenBy(x => x.LastName),
                            "identityNumber" => request.Request.SortDescending ? 
                                x.OrderByDescending(x => x.IdentityNumber) : 
                                x.OrderBy(x => x.IdentityNumber),
                            "monthlyIncome" => request.Request.SortDescending ? 
                                x.OrderByDescending(x => x.MonthlyIncome) : 
                                x.OrderBy(x => x.MonthlyIncome),
                            "riskScore" => request.Request.SortDescending ? 
                                x.OrderByDescending(x => x.RiskScore) : 
                                x.OrderBy(x => x.RiskScore),
                            "createdDate" => request.Request.SortDescending ? 
                                x.OrderByDescending(x => x.CreatedDate) : 
                                x.OrderBy(x => x.CreatedDate),
                            _ => x.OrderByDescending(x => x.CreatedDate)
                        },
                    index: request.Request.PageIndex,
                    size: request.Request.PageSize,
                    enableTracking: false,
                    cancellationToken: cancellationToken
                );

                GetListResponse<GetListIndividualCustomerResponse> response = _mapper.Map<GetListResponse<GetListIndividualCustomerResponse>>(individualCustomers);
                return response;
            }
        }
    }

    public class GetListIndividualCustomerQueryValidator : AbstractValidator<GetListIndividualCustomerQuery>
    {
        public GetListIndividualCustomerQueryValidator()
        {
            RuleFor(x => x.Request.PageIndex).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Request.PageSize).GreaterThan(0);
        }
    }
} 