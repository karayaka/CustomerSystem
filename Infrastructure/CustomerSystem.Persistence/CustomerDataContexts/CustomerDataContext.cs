using System;
using CustomerSystm.Domain.EntitiyModels.CustomerModels;
using Microsoft.EntityFrameworkCore;

namespace CustomerSystem.Persistence.CustomerDataContexts
{
	public class CustomerDataContext:DbContext
	{
		public CustomerDataContext(DbContextOptions options):base(options)
		{
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

		public DbSet<Customer> Customers { get; set; }

	}
}

