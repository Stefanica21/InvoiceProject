namespace InvoiceProject.DTOs
{
	public class InvoiceWithDetailsDTO
	{
        public int Id { get; set; } = 0;
        public int LocationId { get; set; }
        public string? Number { get; set; }
        public DateTime Date { get; set; }
        public string? ClientName { get; set; }
        public int InvoiceDetailsId { get; set; } = 0;
        public string? ProductName { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public decimal Value { get; set; }
    }
}

