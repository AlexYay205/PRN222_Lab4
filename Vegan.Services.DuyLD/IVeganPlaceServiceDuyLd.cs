using Vegan.Entities.DuyLD.Models;

namespace Vegan.Services.DuyLD
{
    public interface IVeganPlaceServiceDuyLd
    {
        // Query statements
        Task<List<VeganPlaceDuyLd>> GetAllAsync();
        Task<VeganPlaceDuyLd?> GetByIdAsync(long id);
        Task<List<VeganPlaceDuyLd>> GetAllAsync(string? placeName, string? categoryName, bool? isActive);

        // Mutation statements: write database
        Task<int> CreateAsync(VeganPlaceDuyLd veganPlace);
        Task<int> UpdateAsync(VeganPlaceDuyLd veganPlace);
        Task<bool> DeleteAsync(long id);
    }
}
