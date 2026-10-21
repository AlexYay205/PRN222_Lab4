using Vegan.Entities.DuyLD.Models;

namespace Vegan.Services.DuyLD
{
    public interface IPlaceFoodServiceDuyLd
    {
        // Query statements
        Task<List<PlaceFoodDuyLd>> GetAllAsync();
        Task<PlaceFoodDuyLd?> GetByIdAsync(long id);
        Task<List<PlaceFoodDuyLd>> GetAllAsync(string foodName, decimal? minPrice, bool? isAvailable);

        // Mutation statements: write database
        Task<int> CreateAsync(PlaceFoodDuyLd placeFood);
        Task<int> UpdateAsync(PlaceFoodDuyLd placeFood);
        Task<bool> DeleteAsync(long id);
    }
}
