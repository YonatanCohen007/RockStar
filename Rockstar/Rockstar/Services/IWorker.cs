using Rockstar.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Rockstar.Services
{
    public interface IWorker
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}