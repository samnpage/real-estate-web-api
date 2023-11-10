using RealEstate.Models.Buyers;

namespace RealEstate.Services.Buyers;
public interface IBuyersService
{
    Task<bool> CreateBuyerContactAsync(CreateBuyers model);
}