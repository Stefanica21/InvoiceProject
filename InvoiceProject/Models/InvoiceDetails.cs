using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceProject.Models
{
    public class InvoiceDetails
    {
        [Key]
        public int Id { get; set; }
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location? Location { get; set; }
        public int InvoiceId { get; set; }

        [ForeignKey("InvoiceId")]
        public Invoice? Invoice { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Value { get; set; }
    }
}

