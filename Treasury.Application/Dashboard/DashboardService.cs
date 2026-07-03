using Treasury.Domain.Entities;

namespace Treasury.Application.Dashboard;

public class DashboardService : IDashboardService
{
    private readonly List<Transaction> transactions = [];

    public DashboardService()
    {
        transactions.AddRange(CreateSeedTransactions());
    }

    public DashboardModel GetDashboard()
    {
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

    public IReadOnlyList<Transaction> GetTransactions() => transactions;

    public void AddTransaction(Transaction transaction)
    {
        ArgumentNullException.ThrowIfNull(transaction);
        transactions.Insert(0, transaction);
    }

    public void UpdateTransaction(Transaction transaction)
    {
        ArgumentNullException.ThrowIfNull(transaction);

        var existing = transactions.FirstOrDefault(t => t == transaction);
        if (existing is null)
        {
            return;
        }

        existing.Date = transaction.Date;
        existing.Description = transaction.Description;
        existing.Amount = transaction.Amount;
        existing.Category = transaction.Category;
    }

    public void DeleteTransaction(Transaction transaction)
    {
        ArgumentNullException.ThrowIfNull(transaction);
        transactions.Remove(transaction);
    }

    private static IEnumerable<Transaction> CreateSeedTransactions()
    {
        return
        [
            new Transaction
            {
                Date = new DateTime(2026, 6, 28),
                Description = "Paycheck",
                Amount = 3200.00m,
                Category = "Income"
            },
            new Transaction
            {
                Date = new DateTime(2026, 6, 25),
                Description = "Groceries",
                Amount = -124.80m,
                Category = "Food"
            },
            new Transaction
            {
                Date = new DateTime(2026, 6, 22),
                Description = "Freelance Project",
                Amount = 850.00m,
                Category = "Income"
            },
            new Transaction
            {
                Date = new DateTime(2026, 6, 20),
                Description = "Rent",
                Amount = -1450.00m,
                Category = "Housing"
            },
            new Transaction
            {
                Date = new DateTime(2026, 6, 18),
                Description = "Electricity Bill",
                Amount = -92.40m,
                Category = "Utilities"
            },
            new Transaction
            {
                Date = new DateTime(2026, 6, 15),
                Description = "Streaming Subscription",
                Amount = -14.99m,
                Category = "Entertainment"
            },
            new Transaction
            {
                Date = new DateTime(2026, 6, 10),
                Description = "Pharmacy",
                Amount = -48.60m,
                Category = "Health"
            },
            new Transaction
            {
                Date = new DateTime(2026, 6, 8),
                Description = "Savings Transfer",
                Amount = -300.00m,
                Category = "Savings"
            },
            new Transaction
            {
                Date = new DateTime(2026, 6, 5),
                Description = "Coffee Shop",
                Amount = -8.75m,
                Category = "Food"
            }
        ];
    }
}