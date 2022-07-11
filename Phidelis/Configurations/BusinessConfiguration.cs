using Microsoft.Extensions.DependencyInjection;
using Phidelis.Service;
using Phidelis.Service.Interfaces;

namespace Phidelis.Configuration
{
    public static class BusinessConfiguration
    {
        public static void ServiceConfiguration(IServiceCollection services)
        {
            services.AddTransient<IEnrolmentService, EnrolmentService>();
        }
    }
}
