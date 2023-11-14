using RealEstate.Data.Entities;
using RealEstate.Models.Buyers;

namespace RealEstate.Services.Buyers;
public interface IBuyersService
{
    Task<ListBuyers?> CreateBuyerContactAsync(CreateBuyers model);
    Task<BuyersEntity?> GetBuyerByIdAsync(int id);
}