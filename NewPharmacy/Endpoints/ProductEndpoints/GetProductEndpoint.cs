using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewPharmacy.Data;

namespace NewPharmacy.Endpoints.ProductEndpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetProductEndpoint : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetProductEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var product = _context.Products.ToList();
            return Ok(product);
        }
    }
}
