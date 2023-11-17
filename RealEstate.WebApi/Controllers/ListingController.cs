using Microsoft.AspNetCore.Mvc;
using RealEstate.Data.Entities;
using RealEstate.Models.Listing;
using RealEstate.Models.Responses;
using RealEstate.Services;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly IListingService _listingService;

        public ListingController(IListingService listingService)
        {
            _listingService = listingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListingEntity>>> GetAllListings()
        {
            var listings = await _listingService.GetAllListingsAsync();
            return Ok(listings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetListingById(int id)
        {
            ListingEntity entity = await _listingService.GetListingByIdAsync(id);

            return entity is not null
                ? Ok(entity)
                : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateListing([FromBody] CreateListing createListing)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _listingService.CreateListingAsync(createListing);
            if (response is not null)
            {
                return Ok(response);
            }
            return BadRequest(new TextResponse("Listing creation unsuccessful"));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateListing([FromRoute] int id, [FromBody] UpdateListing updatedListing)
        {
            var response = await _listingService.UpdateListingAsync(id,updatedListing);

            if (response == null)
            {
                return NotFound();
            }


            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListing(int id)
        {
            var existingListing = await _listingService.GetListingByIdAsync(id);

            if (existingListing == null)
            {
                return NotFound();
            }

            await _listingService.DeleteListingAsync(id);

            return NoContent();
        }
    }
}