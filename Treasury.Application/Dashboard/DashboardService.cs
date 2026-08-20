using Treasury.Application.Transactions;

namespace Treasury.Application.Dashboard;

public class DashboardService : IDashboardService
{
    private readonly ITransactionService _transactionService;
    public DashboardService(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<DashboardModel> GetDashboardAsync()
    {
        var transactions = await _transactionService.GetTransactionsAsync();
        return new DashboardModel
        {
            Balance = 12540.75m,
            MonthlyIncome = 5200.00m,
            MonthlyExpenses = 2850.00m,
            SavingsProgress = 73.5m,
            BudgetSummary = BudgetService.CalculateBudgetSummary(transactions, 4000.00m, 1500.00m),
            Transactions = transactions.ToList()
        };
    }
}