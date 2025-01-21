namespace Domain.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public string SaleNumber { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Customer { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string Branch { get; set; } = string.Empty;
        public List<SaleItem> Items { get; set; } = new();
        public bool IsCancelled { get; set; }
    }
}