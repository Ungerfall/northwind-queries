using System.Collections.Generic;

namespace Northwind.Tasks.WebApi.Data;

public record class LearningTask(string Id, string? ProjectColumns, string? Description);
public record class LearningModule(string Id, string? Name, ICollection<LearningTask> Tasks);
public record class LearningTaskSolution(string Id, string Query, int RowCount);

