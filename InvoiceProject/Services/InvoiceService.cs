using InvoiceProject.DTOs;
using InvoiceProject.Interfaces;
using InvoiceProject.Models;

namespace InvoiceProject.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceDetailsRepository _invoiceDetailsRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository, IInvoiceDetailsRepository invoiceDetailsRepository)
        {
            _invoiceRepository = invoiceRepository;
            _invoiceDetailsRepository = invoiceDetailsRepository;
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesAsync()
        {
            return await _invoiceRepository.GetInvoicesAsync();
        }

        public async Task<Invoice?> GetInvoiceByIdAsync(int id)
        {
            return await _invoiceRepository.GetInvoiceByIdAsync(id);
        }

        public async Task<Invoice> CreateInvoiceAsync(InvoiceWithDetailsDTO invoiceWithDetails)
        {
            var invoice = new Invoice
            {
                LocationId = invoiceWithDetails.LocationId,
                Number = invoiceWithDetails.Number,
                Date = invoiceWithDetails.Date,
                ClientName = invoiceWithDetails.ClientName
            };

            await _invoiceRepository.CreateInvoiceAsync(invoice);

            var invoiceDetails = new InvoiceDetails
            {
                InvoiceId = invoice.Id,
                LocationId = invoiceWithDetails.LocationId,
                ProductName = invoiceWithDetails.ProductName,
                Amount = invoiceWithDetails.Amount,
                Price = invoiceWithDetails.Price,
                Value = invoiceWithDetails.Value
            };

            await _invoiceDetailsRepository.CreateInvoiceDetails(invoiceDetails);
            return invoice;
        }

        public async Task UpdateInvoiceAsync(int id, InvoiceWithDetailsDTO invoiceWithDetails)
        {
            Invoice invoice = new Invoice()
            {
                Id = id,
                LocationId = invoiceWithDetails.LocationId,
                Number = invoiceWithDetails.Number,
                Date = invoiceWithDetails.Date,
                ClientName = invoiceWithDetails.ClientName
            };
            await _invoiceRepository.UpdateInvoiceAsync(invoice);
        }

        public async Task<bool> DeleteInvoiceAsync(int id)
        {
            return await _invoiceRepository.DeleteInvoiceAsync(id);
        }

    }
}

