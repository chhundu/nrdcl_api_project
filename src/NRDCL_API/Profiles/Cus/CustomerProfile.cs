using AutoMapper;
using NRDCL_API.DTOs.Cus;
using NRDCL_API.Models.Cus;

namespace NRDCL_API.Profiles.cus
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            //source -> Target
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CreateCustomerDTO, Customer>();
            CreateMap<UpdateCustomerDTO, Customer>();
        }
    }
}