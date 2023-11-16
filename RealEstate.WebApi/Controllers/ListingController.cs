using Microsoft.AspNetCore.Mvc;
using RealEstate.Data.Entities;
using RealEstate.Models.ListingsModels;
using RealEstate.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<HomeListings>> CreateListing([FromBody] HomeListings homeListings)
        {
            var listing = new ListingEntity
            {
            };

            await _listingService.CreateListingAsync(listing);

        
            return CreatedAtAction(nameof(GetListingById), new { id = listing.Id }, listing);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateListing(int id, [FromBody] HomeListings updatedHomeListings)
        {
            var existingListing = await _listingService.GetListingByIdAsync(id);

            if (existingListing == null)
            {
                return NotFound();
            }

        
            return Ok(existingListing);
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

