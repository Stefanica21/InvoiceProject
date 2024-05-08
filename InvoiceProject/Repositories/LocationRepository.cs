using InvoiceProject.Interfaces;
using InvoiceProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvoiceProject.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationContext _context;

        public LocationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Location>>> GetLocationsAsync()
        {
            return await _context.Locations.ToListAsync();
        }
    }
}

