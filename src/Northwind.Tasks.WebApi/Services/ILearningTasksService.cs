using Northwind.Tasks.WebApi.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Tasks.WebApi.Services;
public interface ILearningTasksService
{
    Task<IReadOnlyCollection<LearningModule>> GetLearningModules();
    Task<(bool IsCorrect, LearningTaskSolution solution)> CheckSolution(string taskId, int rowCount);
}
