using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Northwind.Tasks.WebApi.Data;
using Northwind.Tasks.WebApi.Options;
using Northwind.Tasks.WebApi.Services;
using System;

namespace Northwind.Tasks.WebApi;
public class Program
{
    public static void Main()
    {
        var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults()
            .ConfigureServices(s =>
            {
                s.Configure<CosmosDbOptions>(c =>
                {
                    var connectionString = Environment.GetEnvironmentVariable("COSMOSDB_ConnectionString", EnvironmentVariableTarget.Process);
                    if (string.IsNullOrEmpty(connectionString))
                    {
                        throw new ArgumentNullException("Please specify a valid connection string in your Azure Functions Settings.");
                    }

                    c.ConnectionString = connectionString;
                });
                s.AddSingleton<CosmosClient>(CosmosDbClientFactory.ImplementationFactory);
                s.AddTransient<ILearningTasksService, LearningTasksService>();
            })
            .Build();

        host.Run();
    }
}