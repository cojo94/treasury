namespace Treasury.Application.Dashboard;

public class DashboardService : IDashboardService
{
    private readonly List<TransactionItem> transactions = [];

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
            Transactions = transactions.ToList()
        };
    }

    public IReadOnlyList<TransactionItem> GetTransactions() => transactions;

    public void AddTransaction(TransactionItem transaction)
    {
        ArgumentNullException.ThrowIfNull(transaction);
        transactions.Insert(0, transaction);
    }

    public void UpdateTransaction(TransactionItem transaction)
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

    public void DeleteTransaction(TransactionItem transaction)
    {
        ArgumentNullException.ThrowIfNull(transaction);
        transactions.Remove(transaction);
    }

    private static IEnumerable<TransactionItem> CreateSeedTransactions()
    {
        return
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
            },
            new TransactionItem
            {
                Date = new DateTime(2026, 6, 20),
                Description = "Rent",
                Amount = -1450.00m,
                Category = "Housing"
            },
            new TransactionItem
            {
                Date = new DateTime(2026, 6, 18),
                Description = "Electricity Bill",
                Amount = -92.40m,
                Category = "Utilities"
            },
            new TransactionItem
            {
                Date = new DateTime(2026, 6, 15),
                Description = "Streaming Subscription",
                Amount = -14.99m,
                Category = "Entertainment"
            },
            new TransactionItem
            {
                Date = new DateTime(2026, 6, 10),
                Description = "Pharmacy",
                Amount = -48.60m,
                Category = "Health"
            },
            new TransactionItem
            {
                Date = new DateTime(2026, 6, 8),
                Description = "Savings Transfer",
                Amount = -300.00m,
                Category = "Savings"
            },
            new TransactionItem
            {
                Date = new DateTime(2026, 6, 5),
                Description = "Coffee Shop",
                Amount = -8.75m,
                Category = "Food"
            }
        ];
    }
}