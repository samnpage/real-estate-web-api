using RealEstate.Data.Entities;
using RealEstate.Models.Buyers;
using RealEstate.Models.Responses;

namespace RealEstate.Services.Buyers;
public interface IBuyersService
{
    Task<ListBuyers?> CreateBuyerContactAsync(CreateBuyers model);
    Task<BuyersEntity?> GetBuyerByIdAsync(int id);
    Task<BuyersEntity?> UpdateBuyerByIdAsync(int id, BuyersEntity updatedBuyer);
    Task<TextResponse> DeleteBuyerByIdAsync(int id);
}