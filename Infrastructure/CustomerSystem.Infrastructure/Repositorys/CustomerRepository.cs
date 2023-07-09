using System;
using AutoMapper;
using CustomerSystem.Application.Repositorys;
using CustomerSystem.Application.Services;
using CustomerSystem.Persistence.CustomerDataContexts;
using CustomerSystm.Domain.DTOModels.CustomerDtos;
using CustomerSystm.Domain.EntitiyModels.CustomerModels;
using CustomerSystm.Domain.Exceptions;
using Microsoft.Extensions.Logging;

namespace CustomerSystem.Infrastructure.Repositorys
{
	public class CustomerRepository:Repository,ICustomerRepository
	{
        private readonly CustomerDataContext context;
		private readonly IMapper mapper;
        private readonly IValidationService validationService;
        private readonly IEncryptionService encryptionService;
        private readonly ILogger<CustomerRepository> logger;

        public CustomerRepository(CustomerDataContext _context,
            IMapper _mapper,
            IValidationService _validationService,
            ILogger<CustomerRepository> _logger,
            IEncryptionService _encryptionService) :base(_context)
		{
			context = _context;
            mapper = _mapper;
            validationService = _validationService;
            encryptionService = _encryptionService;
            logger = _logger;
		}

        public async Task AddCustomer(CreateCustomerDto model)
        {
            try
            {
                
                var customer = mapper.Map<Customer>(model);
                await Add(customer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddOrUpdateCustomer(CreateCustomerDto model)
        {
            try
            {
                if(!await validationService.ConfirmeCustomer(mapper.Map<CustomerDto>(model)))
                    throw new ValidationException("Kullanıcı Bilgileri Doğrulanamadı!");
                Customer customer=null;
                if(model.ID!=Guid.Empty)
                    customer = await GetByID<Customer>(model.ID);
                if (customer == null)
                    await AddCustomer(model);
                else
                {
                    var updatedCustomer = mapper.Map<CreateCustomerDto, Customer>(model, customer);
                    Update(updatedCustomer);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteCustomer(Guid id)
        {
            try
            {
                await Delete<Customer>(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CustomerDto> GetCustomer(Guid id)
        {
            try
            {
                var customer= await FindNonDeletedActive<Customer>(t=>t.ID==id);
                return mapper.Map<CustomerDto>(customer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Customer> GetCustomerByTCKN(string TCKN)
        {
            try
            {
                return await FindNonDeletedActive<Customer>(t => t.TCKN.Trim() == TCKN.Trim());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<CustomerListDto> GetCustomers(string q)
        {
            try
            {
                logger.LogInformation("Müşeriler Listelendi q:"+q);
                var customrs = GetNonDeletedAndActive<Customer>(t => true);
                if (!string.IsNullOrEmpty(q))
                {
                    var tq = q.ToLower().Trim();
                    customrs = customrs.Where(t => t.Name.ToLower().Contains(tq) ||
                    t.Surname.Contains(tq) ||
                    t.TCKN.Trim().Contains(q.Trim())||
                    t.Email.ToLower().Trim().Contains(tq)
                    );
                }
                return customrs.Select(s => encryptionService.EncryptionCustomerInfo(s));
                    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

