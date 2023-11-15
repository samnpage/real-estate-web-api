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
    public class HomeController : ControllerBase
    {
        private readonly IListingsService _listingsService;

        public HomeController(IListingsService listingsService)
        {
            _listingsService = listingsService ?? throw new ArgumentNullException(nameof(listingsService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HomeListings>>> GetAllListings()
        {
            var listings = await _listingsService.GetAllListingsAsync();
            var homeListings = listings.Select(listing => MapToListingsModel(listing));
            return Ok(homeListings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HomeListings>> GetListingById(int id)
        {
            var listing = await _listingsService.GetListingByIdAsync(id);

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

            await _listingsService.CreateListingAsync(listing);

            return CreatedAtAction(nameof(GetListingById), new { id = listing.Id }, homeListings);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateListing(int id, [FromBody] HomeListings updatedHomeListings)
        {
            var updatedListing = MapToDataEntity(updatedHomeListings);

            await _listingsService.UpdateListingAsync(id, updatedListing);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListing(int id)
        {
            await _listingsService.DeleteListingAsync(id);

            return NoContent();
        }

        private HomeListings MapToListingsModel(Listings listing)
        {
            return new HomeListings
            {
                Id = listing.Id,
                HomeStyle = listing.HomeStyle,
                Address1 = listing.Address1,
                Address2 = listing.Address2,
                City = listing.City,
                State = listing.State,
                Price = listing.Price,
                ZipCode = listing.ZipCode,
                SquareFootage = listing.SquareFootage
            };
        }

        private Listings MapToDataEntity(HomeListings homeListings)
        {
            return new Listings
            {
                Id = homeListings.Id,
                HomeStyle = homeListings.HomeStyle,
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

