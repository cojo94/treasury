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

    public async Task<IReadOnlyList<Budget>> GetBudgetsAsync()
    {
        return await _budgetRepository.GetBudgetsAsync();
    }

    public async Task<Budget?> GetBudgetByIdAsync(Guid budgetId)
    {
        return await _budgetRepository.GetBudgetByIdAsync(budgetId);
    }

    public async Task<BudgetSummary> GetBudgetSummaryAsync(Guid budgetId)
    {
        var budget = await _budgetRepository.GetBudgetByIdAsync(budgetId);
        if (budget == null)
        {
            throw new ArgumentException($"Budget with ID {budgetId} not found.");
        }

        var transactions = await _transactionRepository.GetTransactionsAsync();

        var budgetTransactions = transactions.Where(t => t.Date >= budget.StartDate && t.Date <= budget.EndDate).ToList();

        return BudgetCalculator.CalculateBudgetSummary(budgetTransactions, budget.PlannedIncome, budget.PlannedExpenses);
    }

    public async Task AddBudgetAsync(Budget budget)
    {
        await _budgetRepository.AddBudgetAsync(budget);
    }

    public async Task UpdateBudgetAsync(Budget budget)
    {
        await _budgetRepository.UpdateBudgetAsync(budget);
    }

    public async Task DeleteBudgetAsync(Budget budget)
    {
        await _budgetRepository.DeleteBudgetAsync(budget);
    }
}