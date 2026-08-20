using Treasury.Domain.Entities;

namespace Treasury.Application.Transactions;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<IReadOnlyList<Transaction>> GetTransactionsAsync()
    {
        return await _transactionRepository.GetTransactionsAsync();
    }

    public async Task AddTransactionAsync(Transaction transaction)
    {
        await _transactionRepository.AddTransactionAsync(transaction);
    }

    public async Task UpdateTransactionAsync(Transaction transaction)
    {
        await _transactionRepository.UpdateTransactionAsync(transaction);
    }

    public async Task DeleteTransactionAsync(Transaction transaction)
    {
        await _transactionRepository.DeleteTransactionAsync(transaction);
    }
}