namespace Treasury.Application.Dashboard;

public class DashboardService
{
    public DashboardModel GetDashboard()
    {
        return new DashboardModel
        {
            Balance = 12540.75m,
            MonthlyIncome = 5200.00m,
            MonthlyExpenses = 2850.00m,
            SavingsProgress = 73.5m,

            Transactions =
            [
                new TransactionItem
                {
                    Date = new DateTime(2026, 6, 28),
                    Description = "Paycheck",
                    Amount = 3200.00m,
                    Category = "Income"
                },
                new TransactionItem
                {
                    Date = new DateTime(2026, 6, 25),
                    Description = "Groceries",
                    Amount = -124.80m,
                    Category = "Food"
                },
                new TransactionItem
                {
                    Date = new DateTime(2026, 6, 22),
                    Description = "Freelance Project",
                    Amount = 850.00m,
                    Category = "Income"
                }
            ]
        };
    }
}