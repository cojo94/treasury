using Treasury.Domain.Entities;
using Treasury.Application.Transactions;

namespace Treasury.Application.Budgets;

public class BudgetService : IBudgetService
{
    private readonly IBudgetRepository _budgetRepository;
    private readonly ITransactionRepository _transactionRepository;
    public BudgetService(IBudgetRepository budgetRepository, ITransactionRepository transactionRepository)
    {
        _budgetRepository = budgetRepository;
        _transactionRepository = transactionRepository;
    }

    public Task<IReadOnlyList<Budget>> GetBudgetsAsync()
    {
        return _budgetRepository.GetBudgetsAsync();
    }

    public Task<Budget?> GetBudgetByIdAsync(Guid budgetId)
    {
        return _budgetRepository.GetBudgetByIdAsync(budgetId);
    }

    public async Task<BudgetSummary> GetBudgetSummaryAsync(Budget budget)
    {
        ArgumentNullException.ThrowIfNull(budget);

        var budgetTransactions = await GetBudgetTransactionsAsync(budget);

        return CalculateBudgetSummary(budget, budgetTransactions);
    }

    public BudgetSummary CalculateBudgetSummary(Budget budget, IReadOnlyList<Transaction> transactions)
    {
        ArgumentNullException.ThrowIfNull(budget);
        ArgumentNullException.ThrowIfNull(transactions);

        return BudgetCalculator.CalculateBudgetSummary(transactions, budget.PlannedIncome, budget.PlannedExpenses);
    }

    public Task<IReadOnlyList<Transaction>> GetBudgetTransactionsAsync(Budget budget)
    {
        ArgumentNullException.ThrowIfNull(budget);

        var startDate = budget.StartDate.ToDateTime(
        TimeOnly.MinValue,
        DateTimeKind.Utc);

        var endDate = budget.EndDate
            .AddDays(1)
            .ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);

        return _transactionRepository.GetTransactionsByDateRangeAsync(
            startDate,
            endDate);
    }

    private static void ValidateBudget(Budget budget)
    {
        ArgumentNullException.ThrowIfNull(budget);

        if (budget.StartDate > budget.EndDate)
        {
            throw new ArgumentException("Budget start date must be on or before the end date", nameof(budget));
        }
    }

    public Task AddBudgetAsync(Budget budget)
    {
        ValidateBudget(budget);
        return _budgetRepository.AddBudgetAsync(budget);
    }

    public Task UpdateBudgetAsync(Budget budget)
    {
        ValidateBudget(budget);
        return _budgetRepository.UpdateBudgetAsync(budget);
    }

    public Task DeleteBudgetAsync(Budget budget)
    {
        return _budgetRepository.DeleteBudgetAsync(budget);
    }
}