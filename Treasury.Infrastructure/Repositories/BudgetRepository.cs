using Treasury.Application.Budgets;
using Treasury.Infrastructure.Data;
using Treasury.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Treasury.Infrastructure.Repositories;

public class BudgetRepository : IBudgetRepository
{
    private readonly TreasuryDbContext _context;
    public BudgetRepository(TreasuryDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Budget>> GetBudgetsAsync()
    {
        return await _context.Budgets.ToListAsync();
    }
    public async Task<Budget?> GetBudgetByIdAsync(Guid budgetId)
    {
        return await _context.Budgets.FindAsync(budgetId);
    }
    public async Task AddBudgetAsync(Budget budget)
    {
        await _context.Budgets.AddAsync(budget);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateBudgetAsync(Budget budget)
    {
        _context.Budgets.Update(budget);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteBudgetAsync(Budget budget)
    {
        _context.Budgets.Remove(budget);
        await _context.SaveChangesAsync();
    }
}