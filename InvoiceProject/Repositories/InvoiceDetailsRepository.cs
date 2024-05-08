using InvoiceProject.Interfaces;
using InvoiceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceProject.Repositories
{
    public class InvoiceDetailsRepository : IInvoiceDetailsRepository
    {

        private readonly ApplicationContext _context;

        public InvoiceDetailsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateInvoiceDetails(InvoiceDetails invoiceDetails)
        {
            _context.InvoiceDetails.Add(invoiceDetails);
            await _context.SaveChangesAsync();
        }

        public async Task<InvoiceDetails?> GetInvoiceDetailsByInvoiceIdAsync(int invoiceid)
        {
            var invoiceDetails = await _context.InvoiceDetails.FirstOrDefaultAsync(invDet => invDet.InvoiceId == invoiceid);

            return invoiceDetails;
        }

        public async Task UpdateInvoiceDetails(InvoiceDetails invoiceDetails)
        {
            _context.InvoiceDetails.Update(invoiceDetails);
            await _context.SaveChangesAsync();
        }
    }
}

