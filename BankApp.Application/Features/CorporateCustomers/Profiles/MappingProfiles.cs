using AutoMapper;
using BankApp.Application.Features.CorporateCustomers.Commands.Create;
using BankApp.Application.Features.CorporateCustomers.Commands.Update;
using BankApp.Application.Features.CorporateCustomers.Queries.GetById;
using BankApp.Application.Features.CorporateCustomers.Queries.GetList;
using BankApp.Domain.Entities;

namespace BankApp.Application.Features.CorporateCustomers.Profiles
{
    /// <summary>
    /// Kurumsal müşteriler için AutoMapper profili.
    /// </summary>
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Command -> Entity
            CreateMap<CreateCorporateCustomerCommand, CorporateCustomer>();
            CreateMap<CreateCorporateCustomerCommand, Customer>();
            CreateMap<UpdateCorporateCustomerCommand, CorporateCustomer>();
            CreateMap<UpdateCorporateCustomerCommand, Customer>();

            // Entity -> Response
            CreateMap<CorporateCustomer, GetByIdCorporateCustomerResponse>();
            CreateMap<CorporateCustomer, GetListCorporateCustomerListItemDto>();
            CreateMap<Customer, GetByIdCorporateCustomerResponse>();
            CreateMap<Customer, GetListCorporateCustomerListItemDto>();
        }
    }
} 