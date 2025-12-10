using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Northwind.Tasks.WebApi.Data;
using Northwind.Tasks.WebApi.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Northwind.Tasks.WebApi;
public class TaskFunctions
{
    private readonly ILogger _logger;
    private readonly ILearningTasksService _tasks;

    public TaskFunctions(ILoggerFactory loggerFactory, ILearningTasksService tasks)
    {
        _logger = loggerFactory.CreateLogger<TaskFunctions>();
        _tasks = tasks;
    }

    [Function("GET /api/modules2")]
    public Task<HttpResponseData> GetModules2([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "modules2")] HttpRequestData req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var response = req.CreateResponse(HttpStatusCode.OK);

        return Task.FromResult(response);
    }

    [Function("GET modules")]
    public async Task<HttpResponseData> GetModules([HttpTrigger(AuthorizationLevel.Function, "get", Route = "modules")] HttpRequestData req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var response = req.CreateResponse(HttpStatusCode.OK);
        List<LearningModule> tasks = (await _tasks.GetLearningModules()).ToList();
        await response.WriteAsJsonAsync(tasks);

        return response;
    }

    [Function("POST tasks_id_solution")]
    public async Task<HttpResponseData> CheckSolution(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "tasks/{id}/solution")] HttpRequestData req,
        string id)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        int? rowCount = (await req.ReadFromJsonAsync<SolutionInput>())?.RowCount;
        if (rowCount == null)
            return req.CreateResponse(HttpStatusCode.BadRequest);

        var (correct, solution) = await _tasks.CheckSolution(id, rowCount.Value);

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(new SolutionRespose(correct, solution));

        return response;
    }
}
