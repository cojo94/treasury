using Treasury.Application.Budgets;
using Treasury.Application.Transactions;
using Treasury.Domain.Entities;

namespace Treasury.Application.Tests.Budgets;

public class BudgetServiceTests
{
    [Fact]
    public async Task AddBudgetAsync_InvalidDates_ThrowsArgumentException()
    {
        // Arrange
        var budgetRepository = new FakeBudgetRepository();
        var transactionRepository = new FakeTransactionRepository();

        var service = new BudgetService(
            budgetRepository,
            transactionRepository);

        var budget = new Budget
        {
            StartDate = new DateOnly(2026, 11, 1),
            EndDate = new DateOnly(2026, 10, 19)
        };

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(
            () => service.AddBudgetAsync(budget));

        Assert.False(budgetRepository.AddBudgetCalled);
    }
}

public class FakeBudgetRepository : IBudgetRepository
{
    public bool AddBudgetCalled { get; private set; }

    public Task<IReadOnlyList<Budget>> GetBudgetsAsync()
    {
        throw new NotImplementedException();
    }
    public Task<Budget?> GetBudgetByIdAsync(Guid budgetId)
    {
        throw new NotImplementedException();
    }
    public Task AddBudgetAsync(Budget budget)
    {
        AddBudgetCalled = true;
        return Task.CompletedTask;
    }


    public Task UpdateBudgetAsync(Budget budget)
    {
        throw new NotImplementedException();
    }
    public Task DeleteBudgetAsync(Budget budget)
    {
        throw new NotImplementedException();
    }
}
public class FakeTransactionRepository : ITransactionRepository
{
    public Task<IReadOnlyList<Transaction>> GetTransactionsAsync()
    {
        throw new NotImplementedException();
    }
    public Task<IReadOnlyList<Transaction>> GetTransactionsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }
    public Task AddTransactionAsync(Transaction transaction)
    {
        throw new NotImplementedException();
    }
    public Task UpdateTransactionAsync(Transaction transaction)
    {
        throw new NotImplementedException();
    }
    public Task DeleteTransactionAsync(Transaction transaction)
    {
        throw new NotImplementedException();
    }
}

