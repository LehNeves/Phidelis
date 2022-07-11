using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Phidelis.Configuration;
using Phidelis.Service;
using Phidelis.Service.Interfaces;

namespace HostedService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    InfraConfiguration.ContextConfiguration(hostContext.Configuration, services);
                    InfraConfiguration.RepositoryConfiguration(services);
                    BusinessConfiguration.ServiceConfiguration(services);
                    services.AddTransient<IEnrolmentService, EnrolmentService>();
                    services.AddHostedService<Worker>();
                });
    }
}
