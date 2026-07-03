namespace Treasury.Application.Dashboard;

public class BudgetSummary
{
    public decimal PlannedIncome { get; set; }
    public decimal PlannedExpenses { get; set; }
    public decimal ActualIncome { get; set; }
    public decimal ActualExpenses { get; set; }
    public decimal IncomeDifference => ActualIncome - PlannedIncome;
    public decimal ExpenseDifference => PlannedExpenses - ActualExpenses;
    public decimal NetDifference => (ActualIncome - ActualExpenses) - (PlannedIncome - PlannedExpenses);
}
