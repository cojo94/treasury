namespace Treasury.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; }
        public required string Description { get; set; }
        public decimal Amount { get; set; }
        public required string Category { get; set; }
    }
}
