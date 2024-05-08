using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceProject.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location? Location { get; set; }

        [Required]
        public string? Number { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string? ClientName { get; set; }
    }
}
