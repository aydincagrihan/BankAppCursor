using AutoMapper;
using BankApp.Application.Features.IndividualCustomers.Commands.Create;
using BankApp.Application.Features.IndividualCustomers.Commands.Update;
using BankApp.Application.Features.IndividualCustomers.Queries.GetById;
using BankApp.Application.Features.IndividualCustomers.Queries.GetList;
using BankApp.Domain.Entities;

namespace BankApp.Application.Features.IndividualCustomers.Profiles
{
    /// <summary>
    /// Bireysel müşteriler için AutoMapper profili.
    /// </summary>
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Command -> Entity
            CreateMap<CreateIndividualCustomerCommand, IndividualCustomer>();
            CreateMap<CreateIndividualCustomerCommand, Customer>();
            CreateMap<UpdateIndividualCustomerCommand, IndividualCustomer>();
            CreateMap<UpdateIndividualCustomerCommand, Customer>();

            // Entity -> Response
            CreateMap<IndividualCustomer, GetByIdIndividualCustomerResponse>();
            CreateMap<IndividualCustomer, GetListIndividualCustomerListItemDto>();
            CreateMap<Customer, GetByIdIndividualCustomerResponse>();
            CreateMap<Customer, GetListIndividualCustomerListItemDto>();
        }
    }
} 