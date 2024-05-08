using InvoiceProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceProject.Interfaces
{
    public interface ILocationRepository
    {
        Task<ActionResult<IEnumerable<Location>>> GetLocationsAsync();
    }
}

