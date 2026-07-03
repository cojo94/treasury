using Treasury.Domain.Entities;

namespace Treasury.Application.Dashboard;

public static class BudgetService
{
    public static BudgetSummary CalculateBudgetSummary(
        IEnumerable<Transaction> transactions,
        decimal plannedIncome,
        decimal plannedExpenses)
    {
        ArgumentNullException.ThrowIfNull(transactions);

        var actualIncome = transactions
            .Where(t => t.Amount > 0)
            .Sum(t => t.Amount);

        var actualExpenses = transactions
            .Where(t => t.Amount < 0)
            .Sum(t => Math.Abs(t.Amount));

        return new BudgetSummary
        {
            PlannedIncome = plannedIncome,
            PlannedExpenses = plannedExpenses,
            ActualIncome = actualIncome,
            ActualExpenses = actualExpenses
        };
    }
}
