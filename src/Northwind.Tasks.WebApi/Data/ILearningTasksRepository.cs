using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Tasks.WebApi.Data;
public interface ILearningTasksRepository
{
    Task<IReadOnlyCollection<LearningModule>> GetLearningModules();
}

