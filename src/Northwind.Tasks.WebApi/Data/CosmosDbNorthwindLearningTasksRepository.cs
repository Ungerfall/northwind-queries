using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Tasks.WebApi.Data;

public class CosmosDbNorthwindLearningTasksRepository : ILearningTasksRepository
{
    private readonly CosmosClient _cosmosClient;

    public CosmosDbNorthwindLearningTasksRepository(CosmosClient cosmosDbOptions)
    {
        _cosmosClient = cosmosDbOptions;
    }

    public async Task<IReadOnlyCollection<LearningModule>> GetLearningModules()
    {
        var container = _cosmosClient.GetContainer(CosmosDb.LearningTasksDatabase, CosmosDb.LearningTasksDatabase_ModuleContainer);
        var query = new QueryDefinition("SELECT * FROM c");
        List<LearningModule> modules = new();
        using (FeedIterator<LearningModule> resultSetIterator = container.GetItemQueryIterator<LearningModule>(query))
        {
            while (resultSetIterator.HasMoreResults)
            {
                var response = await resultSetIterator.ReadNextAsync();
                modules.AddRange(response);
            }
        }

        return modules;
    }
}
