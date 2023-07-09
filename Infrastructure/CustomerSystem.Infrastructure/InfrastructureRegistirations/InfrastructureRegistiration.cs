using System;
using System.Reflection;
using CustomerSystem.Application.Repositorys;
using CustomerSystem.Application.Services;
using CustomerSystem.Infrastructure.Repositorys;
using CustomerSystem.Infrastructure.Services;
using CustomerSystem.Persistence.CustomerDataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerSystem.Infrastructure.InfrastructureRegistirations
{
	public static class InfrastructureRegistiration
	{
        /// <summary>
        /// Database add ioc container
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CustomerDataContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
        }
        /// <summary>
        /// repository add ioc container
        /// </summary>
        /// <param name="services"></param>
        public static void AddRepositorys(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
        /// <summary>
        /// services add ioc container
        /// </summary>
        /// <param name="services"></param>
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<IEncryptionService, EncryptionService>();
            services.AddScoped<ICachingService, CachingService>();
        }
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}

