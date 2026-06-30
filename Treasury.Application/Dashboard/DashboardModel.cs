namespace Treasury.Application.Dashboard;

public class DashboardModel
{
    public decimal Balance { get; set; }
    public decimal MonthlyIncome { get; set; }
    public decimal MonthlyExpenses { get; set; }
    public decimal SavingsProgress { get; set; }

    public List<TransactionItem> Transactions { get; set; } = [];
}