using InvoiceProject.DTOs;
using InvoiceProject.Models;

namespace InvoiceProject.Interfaces
{
    public interface IInvoiceDetailsService
    {
        Task<InvoiceDetails?> GetInvoiceDetailsByInvoiceIdAsync(int invoiceid);
        Task CreateInvoiceDetails(int invoiceId,InvoiceWithDetailsDTO invoiceWithDetails);
        Task UpdateInvoiceDetails(InvoiceWithDetailsDTO invoiceWithDetails);
    }
}

