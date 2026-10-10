using Treasury.Application.Transactions;
using Treasury.Infrastructure.Data;
using Treasury.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Treasury.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IDbContextFactory<TreasuryDbContext> _factory;
    public TransactionRepository(IDbContextFactory<TreasuryDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<IReadOnlyList<Transaction>> GetTransactionsAsync()
    {
        await using var context = await _factory.CreateDbContextAsync();
        return await context.Transactions.AsNoTracking().ToListAsync();
    }

    public async Task AddTransactionAsync(Transaction transaction)
    {
        await using var context = await _factory.CreateDbContextAsync();
        await context.Transactions.AddAsync(transaction);
        await context.SaveChangesAsync();
    }

    public async Task UpdateTransactionAsync(Transaction transaction)
    {
        await using var context = await _factory.CreateDbContextAsync();
        context.Transactions.Update(transaction);
        await context.SaveChangesAsync();
    }

    public async Task DeleteTransactionAsync(Transaction transaction)
    {
        await using var context = await _factory.CreateDbContextAsync();
        context.Transactions.Remove(transaction);
        await context.SaveChangesAsync();
    }
}