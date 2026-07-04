using Microsoft.EntityFrameworkCore;
using Treasury.Domain.Entities;

namespace Treasury.Infrastructure.Data;

public class TreasuryDbContext : DbContext
{
    public TreasuryDbContext(DbContextOptions<TreasuryDbContext> options) : base(options)
    {
    }

    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Budget> Budgets { get; set; }
}