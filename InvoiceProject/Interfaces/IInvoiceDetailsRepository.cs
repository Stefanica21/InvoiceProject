using InvoiceProject.Models;

namespace InvoiceProject.Interfaces
{
    public interface IInvoiceDetailsRepository
    {
        Task<InvoiceDetails?> GetInvoiceDetailsByInvoiceIdAsync(int invoiceid);
        Task CreateInvoiceDetails(InvoiceDetails invoiceDetails);
        Task UpdateInvoiceDetails(InvoiceDetails invoiceDetails);

    }
}

