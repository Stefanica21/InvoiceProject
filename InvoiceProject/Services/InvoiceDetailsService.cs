using InvoiceProject.DTOs;
using InvoiceProject.Interfaces;
using InvoiceProject.Models;

namespace InvoiceProject.Services
{
    public class InvoiceDetailsService : IInvoiceDetailsService
    {
        private readonly IInvoiceDetailsRepository _invoiceDetailsRepository;

        public InvoiceDetailsService(IInvoiceDetailsRepository invoiceDetailsRepository)
        {
            _invoiceDetailsRepository = invoiceDetailsRepository;
        }

        public async Task CreateInvoiceDetails(int invoiceId, InvoiceWithDetailsDTO invoiceWithDetails)
        {
            InvoiceDetails invoiceDetails = new InvoiceDetails
            {
                InvoiceId = invoiceId,
                LocationId = invoiceWithDetails.LocationId,
                ProductName = invoiceWithDetails.ProductName,
                Amount = invoiceWithDetails.Amount,
                Price = invoiceWithDetails.Price,
                Value = invoiceWithDetails.Value
            };
            await _invoiceDetailsRepository.CreateInvoiceDetails(invoiceDetails);
        }

        public async Task<InvoiceDetails?> GetInvoiceDetailsByInvoiceIdAsync(int invoiceid)
        {
            return await _invoiceDetailsRepository.GetInvoiceDetailsByInvoiceIdAsync(invoiceid);
        }

        public async Task UpdateInvoiceDetails(InvoiceWithDetailsDTO invoiceWithDetails)
        {
            InvoiceDetails invoiceDetails = new InvoiceDetails
            {
                Id = invoiceWithDetails.InvoiceDetailsId,
                InvoiceId = invoiceWithDetails.Id,
                LocationId = invoiceWithDetails.LocationId,
                ProductName = invoiceWithDetails.ProductName,
                Amount = invoiceWithDetails.Amount,
                Price = invoiceWithDetails.Price,
                Value = invoiceWithDetails.Value
            };
            await _invoiceDetailsRepository.UpdateInvoiceDetails(invoiceDetails);
        }
    }
}

