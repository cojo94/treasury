using Treasury.Domain.Entities;

namespace Treasury.Application.Budgets;

public interface IBudgetService
{
    Task<IReadOnlyList<Budget>> GetBudgetsAsync();
    Task<Budget?> GetBudgetByIdAsync(Guid budgetId);
    Task<BudgetSummary> GetBudgetSummaryAsync(Budget budget);
    BudgetSummary CalculateBudgetSummary(Budget budget, IReadOnlyList<Transaction> transactions);
    Task<IReadOnlyList<Transaction>> GetBudgetTransactionsAsync(Budget budget);
    Task AddBudgetAsync(Budget budget);
    Task UpdateBudgetAsync(Budget budget);
    Task DeleteBudgetAsync(Budget budget);
}