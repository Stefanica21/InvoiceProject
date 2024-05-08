using InvoiceProject.Interfaces;
using InvoiceProject.Models;
using Microsoft.AspNetCore.Mvc;
namespace InvoiceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            return await _locationService.GetLocationsAsync();
        }
    }
}

