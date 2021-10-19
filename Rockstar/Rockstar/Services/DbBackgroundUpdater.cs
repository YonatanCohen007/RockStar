using Microsoft.Extensions.Hosting;
using Rockstar.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Rockstar.Services
{
    public class DbBackgroundUpdater : BackgroundService
    {
        private readonly IWorker worker;

        public DbBackgroundUpdater(IWorker worker)
        {
            this.worker = worker;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await worker.DoWork(stoppingToken);
        }
    }
}