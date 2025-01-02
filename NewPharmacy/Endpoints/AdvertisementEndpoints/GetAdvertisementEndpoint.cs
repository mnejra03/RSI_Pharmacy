using Microsoft.AspNetCore.Mvc;
using NewPharmacy.Data;
using NewPharmacy.Data.Models;

namespace Pharmacy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAdvertisementEndpoint : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetAdvertisementEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /api/Advertisements
        [HttpGet]
        public IActionResult GetAllAdvertisements()
        {
            var advertisements = _context.Advertisements.ToList();

            if (!advertisements.Any())
            {
                return NotFound("No advertisements found.");
            }

            return Ok(advertisements);
        }
    }
}
