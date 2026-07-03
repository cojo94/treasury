namespace Treasury.Domain.Entities;

public class Budget
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public decimal PlannedIncome { get; set; }
    public decimal PlannedExpenses { get; set; }
    public decimal SavingsGoal { get; set; }
}