using Microsoft.Azure.Cosmos;
using Northwind.Tasks.WebApi.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Tasks.WebApi.Services;
public class LearningTasksService : ILearningTasksService
{
    private readonly CosmosClient _cosmosClient;

    public LearningTasksService(CosmosClient cosmosDbOptions)
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
    public async Task<(bool IsCorrect, LearningTaskSolution solution)> CheckSolution(string taskId, int rowCount)
    {
        var container = _cosmosClient.GetContainer(CosmosDb.LearningTasksDatabase, CosmosDb.LearningTasksDatabase_SolutionContainer);
        var query = new QueryDefinition("SELECT * FROM c WHERE c.id = @taskId OFFSET 0 LIMIT 1")
            .WithParameter("@taskId", taskId);
        List<LearningTaskSolution> solutions = new();
        using (var resultSetIterator = container.GetItemQueryIterator<LearningTaskSolution>(query))
        {
            while (resultSetIterator.HasMoreResults)
            {
                var response = await resultSetIterator.ReadNextAsync();
                solutions.AddRange(response);
            }
        }

        var solution = solutions[0];
        var correct = solution.RowCount == rowCount;
        return (IsCorrect: correct, solution);
    }
}
