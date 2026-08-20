using Treasury.Application.Transactions;
using Treasury.Infrastructure.Data;
using Treasury.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Treasury.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly TreasuryDbContext _context;
    public TransactionRepository(TreasuryDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Transaction>> GetTransactionsAsync()
    {
        return await _context.Transactions.ToListAsync();
    }

    public async Task AddTransactionAsync(Transaction transaction)
    {
        await _context.Transactions.AddAsync(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTransactionAsync(Transaction transaction)
    {
        _context.Transactions.Update(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTransactionAsync(Transaction transaction)
    {
        _context.Transactions.Remove(transaction);
        await _context.SaveChangesAsync();
    }
}