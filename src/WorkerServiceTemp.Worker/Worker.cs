using Microsoft.Extensions.Hosting;
using WorkerServiceTemp.Infrastructure.Repositories;

namespace WorkerServiceTemp.Worker
{
    public class Worker : BackgroundService
    {
        private readonly MyRepository _repository;

        public Worker(MyRepository repository)
        {
            _repository = repository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var entities = await _repository.GetAllAsync();
                foreach (var entity in entities)
                {
                    Console.WriteLine($"Entity: {entity.Name}");
                }
                await Task.Delay(1000, stoppingToken); // Sleep for 1 second
            }
        }
    }
}
