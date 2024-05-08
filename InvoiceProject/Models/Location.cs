using System.ComponentModel.DataAnnotations;

namespace InvoiceProject.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? PostalCode { get; set; }
    }
}

