using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CustomerSystem.Persistence.CustomerDataContexts
{
	public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<CustomerDataContext>
    {
		public DesignTimeDbContextFactory()
		{
		}

        public CustomerDataContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CustomerDataContext>();

            var connectionString = "User ID=admin;Password=55315531;Server=localhost;Port=5432;Database=CustomerDb;Integrated Security=true;Pooling=true;";
            builder.UseNpgsql(connectionString);

            return new CustomerDataContext(builder.Options);
        }
    }
}

