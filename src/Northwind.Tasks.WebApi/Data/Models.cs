using System.Collections.Generic;

namespace Northwind.Tasks.WebApi.Data;

public record class LearningTask(string Name, string Description);
public record class LearningModule(string Name, ICollection<LearningTask> Tasks, string Id);

