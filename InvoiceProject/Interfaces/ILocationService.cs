using InvoiceProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceProject.Interfaces
{
	public interface ILocationService
	{
        Task<ActionResult<IEnumerable<Location>>> GetLocationsAsync();

    }
}

