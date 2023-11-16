using Microsoft.AspNetCore.Mvc;
using RealEstate.Data.Entities;
using RealEstate.Models.ListingsModels; // Remove the .cs from the namespaceZ
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
            var homeListings = listings.Select(listing => new HomeListings
            {
                Address1 = listing.Address1,
                Address2 = listing.Address2,
                City = listing.City,
                State = listing.State,
                Price = listing.Price,
                ZipCode = listing.ZipCode,
                SquareFootage = listing.SquareFootage,
                HomeStyleId = listing.HomeStyleId,
                
            });

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

            var homeListing = new HomeListings
            {
                Address1 = listing.Address1,
                Address2 = listing.Address2,
                City = listing.City,
                State = listing.State,
                Price = listing.Price,
                ZipCode = listing.ZipCode,
                SquareFootage = listing.SquareFootage,
                HomeStyleId = listing.HomeStyleId,
                
            };

            return Ok(homeListing);
        }

        [HttpPost]
        public async Task<ActionResult<HomeListings>> CreateListing([FromBody] HomeListings homeListings)
        {
            var listing = new HomeListings
            {
                Address1 = homeListings.Address1,
                Address2 = homeListings.Address2,
                City = homeListings.City,
                State = homeListings.State,
                Price = homeListings.Price,
                ZipCode = homeListings.ZipCode,
                SquareFootage = homeListings.SquareFootage,
                HomeStyleId = homeListings.HomeStyleId,
                
            };

            await _listingService.CreateListingAsync(listing);

            return CreatedAtAction(nameof(GetListingById), new { id = listing.Id }, homeListings);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateListing(int id, [FromBody] HomeListings updatedHomeListings)
        {
            var existingListing = await _listingService.GetListingByIdAsync(id);

            if (existingListing == null)
            {
                return NotFound();
            }

            existingListing.Address1 = updatedHomeListings.Address1;
            existingListing.Address2 = updatedHomeListings.Address2;
            existingListing.City = updatedHomeListings.City;
            existingListing.State = updatedHomeListings.State;
            existingListing.Price = updatedHomeListings.Price;
            existingListing.ZipCode = updatedHomeListings.ZipCode;
            existingListing.SquareFootage = updatedHomeListings.SquareFootage;
            existingListing.HomeStyleId = updatedHomeListings.HomeStyleId;
            

            await _listingService.UpdateListingAsync(id, existingListing);

            return NoContent();
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

