namespace Treasury.Web.Models
{
    public class TransactionItem
    {
        public DateTime Date { get; set; }
        public required string Description { get; set; }
        public decimal Amount { get; set; }
        public required string Category { get; set; }
    }
}
