using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Northwind.Tasks.WebApi.Options;
using System;

namespace Northwind.Tasks.WebApi.Data;
public class CosmosDbClientFactory
{
    public static Func<IServiceProvider, CosmosClient> ImplementationFactory = (sp) =>
    {
        var cosmosOptions = sp.GetRequiredService<IOptions<CosmosDbOptions>>().Value;
        CosmosClientBuilder configurationBuilder = new CosmosClientBuilder(cosmosOptions.ConnectionString);
        return configurationBuilder
                .Build();
    };
}
