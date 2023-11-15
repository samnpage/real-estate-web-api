using RealEstate.Data.Entities;
using RealEstate.Models.Buyers;
using RealEstate.Models.Responses;

namespace RealEstate.Services.Buyers;
public interface IBuyersService
{
    // CREATE
    Task<ListBuyers?> CreateBuyerContactAsync(CreateBuyers model);

    // READ
    Task<BuyersEntity?> GetBuyerByIdAsync(int id);
    Task<List<BuyersEntity>> GetAllBuyersAsync();

    // UPDATE
    Task<BuyersEntity?> UpdateBuyerByIdAsync(int id, BuyersEntity updatedBuyer);
    
    // DELETE
    Task<TextResponse> DeleteBuyerByIdAsync(int id);
}