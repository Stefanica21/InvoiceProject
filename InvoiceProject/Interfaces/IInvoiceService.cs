using InvoiceProject.DTOs;
using InvoiceProject.Models;

namespace InvoiceProject.Interfaces
{
    public interface IInvoiceService
    {
        Task<IEnumerable<Invoice>> GetInvoicesAsync();
        Task<Invoice?> GetInvoiceByIdAsync(int id);
        Task<Invoice> CreateInvoiceAsync(InvoiceWithDetailsDTO invoiceWithDetails);
        Task UpdateInvoiceAsync(int id, InvoiceWithDetailsDTO invoiceWithDetails);
        Task<bool> DeleteInvoiceAsync(int id);
    }
}

