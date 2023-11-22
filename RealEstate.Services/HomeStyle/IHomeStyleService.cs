using RealEstate.Data.Entities;
using RealEstate.Models.Responses;
using RealEstate.Models.HomeStyle;


namespace RealEstate.Services.HomeStyle;
public interface IHomeStyleService
{
    // CREATE
    Task<bool> CreateHomeStyleAsync(CreateHomeStyle model);

    // READ

    Task<HomeStyleDetail?> GetHomeStyleByIdAsync(int id);
    Task<List<HomeStyleEntity>> GetAllHomeStylesAsync();

    // UPDATE
    Task<TextResponse> UpdateHomeStyleByIdAsync(int id, CreateHomeStyle updatedHomeStyle);
    
    // DELETE
    Task<TextResponse> DeleteHomeStyleByIdAsync(int id);
}