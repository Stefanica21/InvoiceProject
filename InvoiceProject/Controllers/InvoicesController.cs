using Microsoft.AspNetCore.Mvc;
using InvoiceProject.Models;
using InvoiceProject.DTOs;
using InvoiceProject.Interfaces;


namespace InvoiceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IInvoiceDetailsService _invoiceDetailsService;

        public InvoicesController(IInvoiceService invoiceService, IInvoiceDetailsService invoiceDetailsService)
        {
            _invoiceService = invoiceService;
            _invoiceDetailsService = invoiceDetailsService;
        }

        [HttpGet]
        public async Task<IEnumerable<Invoice>> GetInvoices()
        {
            return await _invoiceService.GetInvoicesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

        [HttpGet("details/{id}")]
        public async Task<ActionResult<InvoiceDetails>> GetInvoiceDetails(int id)
        {
            var invoiceDetails = await _invoiceDetailsService.GetInvoiceDetailsByInvoiceIdAsync(id);

            if (invoiceDetails == null)
            {
                return NotFound();
            }

            return invoiceDetails;
        }

        [HttpPost]
        public async Task CreateInvoice(InvoiceWithDetailsDTO invoiceWithDetails)
        {
            var invoice = await _invoiceService.CreateInvoiceAsync(invoiceWithDetails);
            await _invoiceDetailsService.CreateInvoiceDetails(invoice.Id, invoiceWithDetails);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoice(int id, InvoiceWithDetailsDTO invoiceWithDetails)
        {
            if (id != invoiceWithDetails.Id)
            {
                return BadRequest();
            }

            await _invoiceService.UpdateInvoiceAsync(id, invoiceWithDetails);
            await _invoiceDetailsService.UpdateInvoiceDetails(invoiceWithDetails);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var result = await _invoiceService.DeleteInvoiceAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
