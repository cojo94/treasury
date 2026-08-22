using Treasury.Application.Budgets;
using Treasury.Domain.Entities;

namespace Treasury.Application.Tests.Budgets;

public class BudgetCalculatorTests
{
    [Fact]
    public void CalculateBudgetSummary_ReturnsCorrectValues()
    {
        // Arrange
        var transactions = new List<Transaction>
{
    new()
    {
        Date = new DateTime(2026, 8, 5),
        Description = "Salary",
        Amount = 20000m,
        Category = "Income"
    },
    new()
    {
        Date = new DateTime(2026, 8, 10),
        Description = "Freelance",
        Amount = 2000m,
        Category = "Income"
    },
    new()
    {
        Date = new DateTime(2026, 8, 12),
        Description = "Rent",
        Amount = -8000m,
        Category = "Housing"
    },
    new()
    {
        Date = new DateTime(2026, 8, 15),
        Description = "Food",
        Amount = -2000m,
        Category = "Food"
    }
};

        // Act
        var result = BudgetCalculator.CalculateBudgetSummary(
            transactions,
            20000m,
            15000m);

        // Assert
        Assert.Equal(20000m, result.PlannedIncome);
        Assert.Equal(22000m, result.ActualIncome);
        Assert.Equal(2000m, result.IncomeDifference);

        Assert.Equal(15000m, result.PlannedExpenses);
        Assert.Equal(10000m, result.ActualExpenses);
        Assert.Equal(5000m, result.ExpenseDifference);

        Assert.Equal(7000m, result.NetDifference);
    }
}