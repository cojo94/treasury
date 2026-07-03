using Treasury.Domain.Entities;

namespace Treasury.Application.Dashboard;

public interface IDashboardService
{
    DashboardModel GetDashboard();
    IReadOnlyList<Transaction> GetTransactions();
    void AddTransaction(Transaction transaction);
    void UpdateTransaction(Transaction transaction);
    void DeleteTransaction(Transaction transaction);
}
