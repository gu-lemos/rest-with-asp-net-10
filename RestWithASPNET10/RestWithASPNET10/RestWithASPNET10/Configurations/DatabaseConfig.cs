using Microsoft.EntityFrameworkCore;
using RestWithASPNET10.Model.Context;

namespace RestWithASPNET10.Configurations
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:SqlConnection"];

            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Connection string 'SqlConnection' not found.");

            services.AddDbContext<SqlContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
