using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkerServiceTemp.Infrastructure.Repositories;

namespace WorkerServiceTemp.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            // Load the connection string from configuration
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Register MyRepository with the connection string
            builder.Services.AddSingleton(new MyRepository(connectionString));

            builder.Services.AddHostedService<Worker>();

            var host = builder.Build();
            host.Run();
        }
    }
}
