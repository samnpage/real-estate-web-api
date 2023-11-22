using RealEstate.Data.Entities;
using RealEstate.Models.Buyer;
using RealEstate.Models.Responses;

namespace RealEstate.Services.Buyer;
public interface IBuyerService
{
    // CREATE
    Task<BuyerList?> CreateBuyerContactAsync(BuyerCreate model);

    // READ
    Task<BuyerEntity?> GetBuyerByIdAsync(int id);
    Task<List<BuyerEntity>> GetAllBuyersAsync();

    // UPDATE
    Task<BuyerEntity?> UpdateBuyerByIdAsync(int id, BuyerEntity updatedBuyer);
    
    // DELETE
    Task<TextResponse> DeleteBuyerByIdAsync(int id);
}