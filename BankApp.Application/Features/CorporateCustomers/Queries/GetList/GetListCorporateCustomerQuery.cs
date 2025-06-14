using AutoMapper;
using BankApp.Application.Features.CorporateCustomers.Constants;
using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using Core.Application.Pipelines.Validation;
using Core.Application.Requests;
using Core.Persistence.Paging;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Application.Features.CorporateCustomers.Queries.GetList
{
    /// <summary>
    /// Kurumsal müşteri listesi getirme sorgusu.
    /// </summary>
    public class GetListCorporateCustomerQuery : IRequest<GetListResponse<GetListCorporateCustomerResponse>>, IValidationRequest
    {
        public GetListCorporateCustomerRequest Request { get; set; }

        public class GetListCorporateCustomerQueryHandler : IRequestHandler<GetListCorporateCustomerQuery, GetListResponse<GetListCorporateCustomerResponse>>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly IMapper _mapper;

            public GetListCorporateCustomerQueryHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListCorporateCustomerResponse>> Handle(GetListCorporateCustomerQuery request, CancellationToken cancellationToken)
            {
                IPaginate<CorporateCustomer> corporateCustomers = await _corporateCustomerRepository.GetListAsync(
                    predicate: x => string.IsNullOrEmpty(request.Request.SearchTerm) || 
                        x.Customer.CustomerNumber.Contains(request.Request.SearchTerm) ||
                        x.Customer.PhoneNumber.Contains(request.Request.SearchTerm) ||
                        x.Customer.Email.Contains(request.Request.SearchTerm) ||
                        x.CompanyName.Contains(request.Request.SearchTerm) ||
                        x.TaxNumber.Contains(request.Request.SearchTerm),
                    include: x => x.Include(x => x.Customer),
                    orderBy: x => string.IsNullOrEmpty(request.Request.SortBy) ? 
                        x.OrderByDescending(x => x.CreatedDate) :
                        request.Request.SortBy switch
                        {
                            "customerNumber" => request.Request.SortDescending ? 
                                x.OrderByDescending(x => x.Customer.CustomerNumber) : 
                                x.OrderBy(x => x.Customer.CustomerNumber),
                            "companyName" => request.Request.SortDescending ? 
                                x.OrderByDescending(x => x.CompanyName) : 
                                x.OrderBy(x => x.CompanyName),
                            "taxNumber" => request.Request.SortDescending ? 
                                x.OrderByDescending(x => x.TaxNumber) : 
                                x.OrderBy(x => x.TaxNumber),
                            "annualRevenue" => request.Request.SortDescending ? 
                                x.OrderByDescending(x => x.AnnualRevenue) : 
                                x.OrderBy(x => x.AnnualRevenue),
                            "employeeCount" => request.Request.SortDescending ? 
                                x.OrderByDescending(x => x.EmployeeCount) : 
                                x.OrderBy(x => x.EmployeeCount),
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

                GetListResponse<GetListCorporateCustomerResponse> response = _mapper.Map<GetListResponse<GetListCorporateCustomerResponse>>(corporateCustomers);
                return response;
            }
        }
    }

    public class GetListCorporateCustomerQueryValidator : AbstractValidator<GetListCorporateCustomerQuery>
    {
        public GetListCorporateCustomerQueryValidator()
        {
            RuleFor(x => x.Request.PageIndex).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Request.PageSize).GreaterThan(0);
        }
    }
} 