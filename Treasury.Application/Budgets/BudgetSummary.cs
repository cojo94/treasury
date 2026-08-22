namespace Treasury.Application.Budgets;

public class BudgetSummary
{
    public decimal PlannedIncome { get; set; }
    public decimal PlannedExpenses { get; set; }
    public decimal SavingsGoal { get; set; }
    public decimal ActualIncome { get; set; }
    public decimal ActualExpenses { get; set; }
    public decimal ActualSavings => ActualIncome - ActualExpenses;
    public decimal IncomeDifference => ActualIncome - PlannedIncome;
    public decimal ExpenseDifference => PlannedExpenses - ActualExpenses;
    public decimal SavingsDifference => ActualSavings - SavingsGoal;
    public decimal NetDifference => (ActualIncome - ActualExpenses) - (PlannedIncome - PlannedExpenses);
}
