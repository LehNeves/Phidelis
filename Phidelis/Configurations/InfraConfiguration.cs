using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phidelis.Repository;
using Phidelis.Repository.Context;
using Phidelis.Repository.Interfaces;

namespace Phidelis.Configuration
{
    public static class InfraConfiguration
    {
        public static void ContextConfiguration(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<PhidelisEFContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<PhidelisEFContext>();
        }

        public static void RepositoryConfiguration(IServiceCollection services)
        {
            services.AddTransient<IEnrolmentRepository, EnrolmentRepository>();
        }
    }
}
