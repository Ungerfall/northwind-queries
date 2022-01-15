using Northwind.Tasks.WebApi.Data;

namespace Northwind.Tasks.WebApi;

public record class SolutionInput(int RowCount);
public record class SolutionRespose(bool IsCorrect, LearningTaskSolution solution);
