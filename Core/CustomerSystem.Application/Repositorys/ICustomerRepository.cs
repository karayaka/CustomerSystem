using System;
using CustomerSystm.Domain.DTOModels.CustomerDtos;
using CustomerSystm.Domain.EntitiyModels.CustomerModels;

namespace CustomerSystem.Application.Repositorys
{
	public interface ICustomerRepository:IRepository
	{
        /// <summary>
        /// Get Customer by tckn
        /// </summary>
        /// <param name="TCKN"></param>
        /// <returns></returns>
        Task<Customer> GetCustomerByTCKN(string TCKN);

        /// <summary>
        ///method adding or deleting customers
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task AddOrUpdateCustomer(CreateCustomerDto model);
        /// <summary>
        /// Add Customer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task AddCustomer(CreateCustomerDto model);

        /// <summary>
        /// Delete Customer By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		Task DeleteCustomer(Guid id);
        /// <summary>
        /// Get Customer By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		Task<CustomerDto> GetCustomer(Guid id);
        /// <summary>
        /// Gel All Customer searhable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		IQueryable<CustomerListDto> GetCustomers(string q);


	}
}

