namespace Treasury.Application.Dashboard;

public interface IDashboardService
{
    DashboardModel GetDashboard();
    IReadOnlyList<TransactionItem> GetTransactions();
    void AddTransaction(TransactionItem transaction);
    void UpdateTransaction(TransactionItem transaction);
    void DeleteTransaction(TransactionItem transaction);
}
