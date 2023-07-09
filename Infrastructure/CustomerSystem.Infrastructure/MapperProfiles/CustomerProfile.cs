using System;
using AutoMapper;
using CustomerSystm.Domain.DTOModels.CustomerDtos;
using CustomerSystm.Domain.EntitiyModels.CustomerModels;

namespace CustomerSystem.Infrastructure.MapperProfiles
{
	public class CustomerProfile:Profile
	{
		public CustomerProfile()
		{
			CreateMap<CreateCustomerDto, CustomerDto>().ReverseMap();
			CreateMap<CreateCustomerDto, Customer>().ReverseMap();
			CreateMap<Customer, CustomerDto>().ReverseMap();
		}
	}
}

