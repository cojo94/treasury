using Treasury.Application.Transactions;
using Treasury.Application.Budgets;

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
            BudgetSummary = BudgetCalculator.CalculateBudgetSummary(transactions, 4000.00m, 1500.00m),
            Transactions = transactions.ToList()
        };
    }
}