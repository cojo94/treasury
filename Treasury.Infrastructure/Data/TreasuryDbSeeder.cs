using Treasury.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Treasury.Infrastructure.Data;

public class TreasuryDbSeeder
{
    private readonly TreasuryDbContext _context;
    public TreasuryDbSeeder(TreasuryDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await SeedTransactionsAsync();
        await SeedBudgetsAsync();
    }

    private async Task SeedTransactionsAsync()
    {
        if (!await _context.Transactions.AnyAsync())
        {
            var transactions = new List<Transaction>
            {
                new Transaction
            {
                Date = new DateTime(2026, 6, 28, 0, 0, 0, DateTimeKind.Utc),
                Description = "Paycheck",
                Amount = 3200.00m,
                Category = "Income"
            },
            new Transaction
            {
                Date = new DateTime(2026, 6, 25, 0, 0, 0, DateTimeKind.Utc),
                Description = "Groceries",
                Amount = -124.80m,
                Category = "Food"
            },
            new Transaction
            {
                Date = new DateTime(2026, 6, 22, 0, 0, 0, DateTimeKind.Utc),
                Description = "Freelance Project",
                Amount = 850.00m,
                Category = "Income"
            },
            new Transaction
            {
                Date = new DateTime(2026, 6, 20, 0, 0, 0, DateTimeKind.Utc),
                Description = "Rent",
                Amount = -1450.00m,
                Category = "Housing"
            },
            new Transaction
            {
                Date = new DateTime(2026, 6, 18, 0, 0, 0, DateTimeKind.Utc),
                Description = "Electricity Bill",
                Amount = -92.40m,
                Category = "Utilities"
            },
            new Transaction
            {
                Date = new DateTime(2026, 6, 15, 0, 0, 0, DateTimeKind.Utc),
                Description = "Streaming Subscription",
                Amount = -14.99m,
                Category = "Entertainment"
            },
            new Transaction
            {
                Date = new DateTime(2026, 6, 10, 0, 0, 0, DateTimeKind.Utc),
                Description = "Pharmacy",
                Amount = -48.60m,
                Category = "Health"
            },
            new Transaction
            {
                Date = new DateTime(2026, 6, 8, 0, 0, 0, DateTimeKind.Utc),
                Description = "Savings Transfer",
                Amount = -300.00m,
                Category = "Savings"
            },
            new Transaction
            {
                Date = new DateTime(2026, 6, 5, 0, 0, 0, DateTimeKind.Utc),
                Description = "Coffee Shop",
                Amount = -8.75m,
                Category = "Food"
            }
            };
            await _context.Transactions.AddRangeAsync(transactions);
            await _context.SaveChangesAsync();
        }
    }
    private async Task SeedBudgetsAsync()
    {
        if (!await _context.Budgets.AnyAsync())
        {
            var budgets = new List<Budget>
            {
                new Budget
                {
                    StartDate = new DateTime(2026, 6, 1, 0, 0, 0, DateTimeKind.Utc),
                    EndDate = new DateTime(2026, 6, 30, 0, 0, 0, DateTimeKind.Utc),
                    PlannedIncome = 5000.00m,
                    PlannedExpenses = 3500.00m,
                    SavingsGoal = 1000.00m
                },
                new Budget
                {
                    StartDate = new DateTime(2026, 7, 1, 0, 0, 0, DateTimeKind.Utc),
                    EndDate = new DateTime(2026, 7, 31, 0, 0, 0, DateTimeKind.Utc),
                    PlannedIncome = 5200.00m,
                    PlannedExpenses = 3600.00m,
                    SavingsGoal = 1200.00m
                },
                new Budget
                {
                    StartDate = new DateTime(2026, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    EndDate = new DateTime(2026, 8, 31, 0, 0, 0, DateTimeKind.Utc),
                    PlannedIncome = 5400.00m,
                    PlannedExpenses = 3700.00m,
                    SavingsGoal = 1300.00m
                }
            };
            await _context.Budgets.AddRangeAsync(budgets);
            await _context.SaveChangesAsync();
        }
    }
}