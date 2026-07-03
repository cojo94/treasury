using Treasury.Application.Dashboard;
using Treasury.Domain.Entities;

namespace Treasury.Application.Tests;

public class BudgetServiceTests
{
    [Fact]
    public void CalculateBudgetSummary_ComparesPlannedAndActualValues()
    {
        var transactions = new List<Transaction>
        {
            new() { Date = new DateTime(2026, 7, 1), Description = "Salary", Amount = 5000m, Category = "Income" },
            new() { Date = new DateTime(2026, 7, 2), Description = "Groceries", Amount = -200m, Category = "Food" },
            new() { Date = new DateTime(2026, 7, 3), Description = "Rent", Amount = -1200m, Category = "Housing" }
        };

        var summary = BudgetService.CalculateBudgetSummary(transactions, 4000m, 1500m);

        Assert.Equal(5000m, summary.ActualIncome);
        Assert.Equal(1400m, summary.ActualExpenses);
        Assert.Equal(4000m, summary.PlannedIncome);
        Assert.Equal(1500m, summary.PlannedExpenses);
        Assert.Equal(1000m, summary.IncomeDifference);
        Assert.Equal(100m, summary.ExpenseDifference);
        Assert.Equal(1100m, summary.NetDifference);
    }
}
