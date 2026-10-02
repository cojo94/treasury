using Treasury.Domain.Entities;

namespace Treasury.Application.Budgets;

public interface IBudgetService
{
    Task<IReadOnlyList<Budget>> GetBudgetsAsync();
    Task<Budget?> GetBudgetByIdAsync(Guid budgetId);
    Task<BudgetSummary> GetBudgetSummaryAsync(Guid budgetId);
    Task<IReadOnlyList<Transaction>> GetBudgetTransactionsAsync(Guid budgetId);
    Task AddBudgetAsync(Budget budget);
    Task UpdateBudgetAsync(Budget budget);
    Task DeleteBudgetAsync(Budget budget);
}