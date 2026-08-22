using Treasury.Domain.Entities;

namespace Treasury.Application.Budgets;

public interface IBudgetRepository
{
    Task<IReadOnlyList<Budget>> GetBudgetsAsync();
    Task<Budget?> GetBudgetByIdAsync(Guid budgetId);
    Task AddBudgetAsync(Budget budget);
    Task UpdateBudgetAsync(Budget budget);
    Task DeleteBudgetAsync(Budget budget);
}