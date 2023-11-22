using RealEstate.Data.Entities;
using RealEstate.Models.Buyer;
using RealEstate.Models.Responses;

namespace RealEstate.Services.Buyer;
public interface IBuyerService
{
    // CREATE
    Task<bool> CreateBuyerContactAsync(BuyerCreate model);

    // READ
    Task<BuyerDetail?> GetBuyerByIdAsync(int id);
    Task<List<BuyerEntity>> GetAllBuyersAsync();

    // UPDATE
    Task<TextResponse> UpdateBuyerByIdAsync(int id, BuyerUpdate updatedBuyer);
    
    // DELETE
    Task<TextResponse> DeleteBuyerByIdAsync(int id);
}