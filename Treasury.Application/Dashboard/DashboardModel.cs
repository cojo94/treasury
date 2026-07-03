using Treasury.Domain.Entities;

namespace Treasury.Application.Dashboard;

public class DashboardModel
{
    public decimal Balance { get; set; }
    public decimal MonthlyIncome { get; set; }
    public decimal MonthlyExpenses { get; set; }
    public decimal SavingsProgress { get; set; }

    public BudgetSummary BudgetSummary { get; set; } = new();
    public List<Transaction> Transactions { get; set; } = [];
}