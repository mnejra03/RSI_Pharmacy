using Microsoft.AspNetCore.Mvc;
using NewPharmacy.Data.Models;
using NewPharmacy.Data;

[ApiController]

[Route("api/[controller]")]

public class PostAdvertisementEndpoint : ControllerBase

{

    private readonly ApplicationDbContext _context;

    public PostAdvertisementEndpoint(ApplicationDbContext context)

    {
        _context = context;
    }

    [HttpPost]

    public async Task<IActionResult> CreateAdvertisement([FromBody] Advertisement advertisement)

    {

        if (advertisement == null || string.IsNullOrEmpty(advertisement.Title) || string.IsNullOrEmpty(advertisement.imageURL))

        {

            return BadRequest("Invalid advertisement data.");

        }

        try

        {

            await _context.Advertisements.AddAsync(advertisement);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateAdvertisement), new { id = advertisement.Id }, advertisement);

        }

        catch (Exception ex)

        {

            return StatusCode(500, $"Internal server error: {ex.Message}");

        }

    }

}

