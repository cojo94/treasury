using Treasury.Application.Budgets;
using Treasury.Infrastructure.Data;
using Treasury.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Treasury.Infrastructure.Repositories;

public class BudgetRepository : IBudgetRepository
{
    private readonly IDbContextFactory<TreasuryDbContext> _factory;
    public BudgetRepository(IDbContextFactory<TreasuryDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<IReadOnlyList<Budget>> GetBudgetsAsync()
    {
        await using var context = await _factory.CreateDbContextAsync();
        return await context.Budgets.AsNoTracking().ToListAsync();
    }
    public async Task<Budget?> GetBudgetByIdAsync(Guid budgetId)
    {
        await using var context = await _factory.CreateDbContextAsync();
        return await context.Budgets.AsNoTracking().FirstOrDefaultAsync(b => b.Id == budgetId);
    }
    public async Task AddBudgetAsync(Budget budget)
    {
        await using var context = await _factory.CreateDbContextAsync();
        await context.Budgets.AddAsync(budget);
        await context.SaveChangesAsync();
    }
    public async Task UpdateBudgetAsync(Budget budget)
    {
        await using var context = await _factory.CreateDbContextAsync();
        context.Budgets.Update(budget);
        await context.SaveChangesAsync();
    }
    public async Task DeleteBudgetAsync(Budget budget)
    {
        await using var context = await _factory.CreateDbContextAsync();
        context.Budgets.Remove(budget);
        await context.SaveChangesAsync();
    }
}