using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Phidelis.Service.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HostedService
{
    public class Worker : IHostedService, IDisposable
    {
        private Timer _timer;
        public IServiceProvider Services { get; }

        public Worker(IServiceProvider services)
        {
            Services = services;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using (var scope = Services.CreateScope())
            {
                var scoped = scope.ServiceProvider.GetService<IEnrolmentService>();

                var hosted = new HostedService(scoped);
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}

