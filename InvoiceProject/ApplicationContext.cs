using Microsoft.EntityFrameworkCore;
using InvoiceProject.Models;

namespace InvoiceProject
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

    }
}
