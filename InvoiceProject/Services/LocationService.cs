using InvoiceProject.Interfaces;
using InvoiceProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceProject.Services
{
    public class LocationService : ILocationService
    {

        private readonly ILocationRepository _repository;
        public LocationService(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ActionResult<IEnumerable<Location>>> GetLocationsAsync()
        {
            return await _repository.GetLocationsAsync();
        }
    }
}

