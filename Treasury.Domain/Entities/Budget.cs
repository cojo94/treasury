namespace Treasury.Domain.Entities;

public class Budget
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }

    public decimal PlannedIncome { get; set; }
    public decimal PlannedExpenses { get; set; }
    public decimal SavingsGoal { get; set; }
}