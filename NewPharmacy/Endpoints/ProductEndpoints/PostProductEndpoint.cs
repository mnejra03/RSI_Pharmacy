using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewPharmacy.Data;
using NewPharmacy.Data.Models;


namespace NewPharmacy.Endpoints.ProductEndpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostProductEndpoint : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PostProductEndpoint(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product not found");
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction("GetProductById", new { id = product.Id }, product);
        }
    }
}