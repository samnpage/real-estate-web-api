using Microsoft.AspNetCore.Mvc;
using RealEstate.Data.Entities;
using RealEstate.Models.ListingsModels;
using RealEstate.Models.ListingsModels.cs;
using RealEstate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _listingService = listingService ?? throw new ArgumentNullException(nameof(listingService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HomeListings>>> GetAllListings()
        {
            var listings = await _listingService.GetAllListingsAsync();
            var homeListings = listings.Select(listing => MapToListingsModel(listing));
            return Ok(homeListings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HomeListings>> GetListingById(int id)
        {
            var listing = await _listingService.GetListingByIdAsync(id);

            if (listing == null)
            {
                return NotFound();
            }

            var homeListing = MapToListingsModel(listing);

            return Ok(homeListing);
        }

        [HttpPost]
        public async Task<ActionResult<HomeListings>> CreateListing([FromBody] HomeListings homeListings)
        {
            var listing = MapToDataEntity(homeListings);

            await _listingService.CreateListingAsync(listing);

            return CreatedAtAction(nameof(GetListingById), new { id = listing.Id }, homeListings);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateListing(int id, [FromBody] HomeListings updatedHomeListings)
        {
            var updatedListing = MapToDataEntity(updatedHomeListings);

            await _listingService.UpdateListingAsync(id, updatedListing);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListing(int id)
        {
            await _listingService.DeleteListingAsync(id);

            return NoContent();
        }

        private HomeListings MapToListingsModel(ListingEntity listing)
        {
            return new HomeListings
            {
                HomeStyle = listing.HomeStyle.Name,
                Address1 = listing.Address1,
                Address2 = listing.Address2,
                City = listing.City,
                State = listing.State,
                Price = listing.Price,
                ZipCode = listing.ZipCode,
                SquareFootage = listing.SquareFootage
            };
        }

        private ListingEntity MapToDataEntity(HomeListings homeListings)
        {
            return new ListingEntity
            {
                HomeStyleId = homeListings.HomeStyleId,
                Address1 = homeListings.Address1,
                Address2 = homeListings.Address2,
                City = homeListings.City,
                State = homeListings.State,
                Price = homeListings.Price,
                ZipCode = homeListings.ZipCode
                
            };
        }
    }
}

