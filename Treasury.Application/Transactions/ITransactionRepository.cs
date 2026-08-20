using Treasury.Domain.Entities;

namespace Treasury.Application.Transactions;

public interface ITransactionRepository
{
    Task<IReadOnlyList<Transaction>> GetTransactionsAsync();
    Task AddTransactionAsync(Transaction transaction);
    Task UpdateTransactionAsync(Transaction transaction);
    Task DeleteTransactionAsync(Transaction transaction);
}