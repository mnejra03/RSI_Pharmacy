//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace NewPharmacy.Endpoints.AdvertisementEndpoints
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DeleteAdvertisementEndpoint : ControllerBase
//    {
//    }
//}

using Microsoft.AspNetCore.Mvc;
using NewPharmacy.Data;
using NewPharmacy.Data.Models;

[ApiController]
[Route("api/[controller]")]
public class DeleteAdvertisementsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DeleteAdvertisementsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdvertisement(int id)
    {
        // Pronađi oglas po ID-u
        var advertisement = await _context.Advertisements.FindAsync(id);
        if (advertisement == null)
        {
            return NotFound("Advertisement not found.");
        }

        try
        {
            // Ukloni oglas iz baze
            _context.Advertisements.Remove(advertisement);
            await _context.SaveChangesAsync();

            return NoContent(); // Uspešno obrisano, vraća 204 No Content
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
