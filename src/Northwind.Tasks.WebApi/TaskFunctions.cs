using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Northwind.Tasks.WebApi.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Northwind.Tasks.WebApi
{
    public class TaskFunctions
    {
        private readonly ILogger _logger;
        private readonly ILearningTasksRepository _tasks;

        public TaskFunctions(ILoggerFactory loggerFactory, ILearningTasksRepository tasks)
        {
            _logger = loggerFactory.CreateLogger<TaskFunctions>();
            _tasks = tasks;
        }

        [Function("GetAllModules")]
        public async Task<HttpResponseData> Index([HttpTrigger(AuthorizationLevel.Function, "get", Route = "modules")] HttpRequestData req)
        {

            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            List<LearningModule> tasks = (await _tasks.GetLearningModules()).ToList();
            await response.WriteAsJsonAsync(tasks);

            return response;
        }
    }
}
