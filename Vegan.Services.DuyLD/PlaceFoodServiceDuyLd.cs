using Vegan.Entities.DuyLD.Models;
using Vegan.Repositories.DuyLD;

namespace Vegan.Services.DuyLD
{
    public class PlaceFoodServiceDuyLd : IPlaceFoodServiceDuyLd
    {
        public readonly PlaceFoodRepositoryDuyLd _repository;

        public PlaceFoodServiceDuyLd()
            => _repository ??= new PlaceFoodRepositoryDuyLd();

        public async Task<int> CreateAsync(PlaceFoodDuyLd placeFood)
        {
            try
            {
                return await _repository.CreateAsync(placeFood);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating place food. " + ex.Message, ex);
            }
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var placeFood = await _repository.GetByIdAsync(id);

                if (placeFood == null)
                {
                    throw new KeyNotFoundException($"Place food with ID {id} not found.");
                }

                return await _repository.RemoveAsync(placeFood);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting place food. " + ex.Message, ex);
            }
        }

        public async Task<List<PlaceFoodDuyLd>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all place foods. " + ex.Message, ex);
            }
        }

        public async Task<List<PlaceFoodDuyLd>> GetAllAsync(
            string foodName,
            decimal? minPrice,
            bool? isAvailable)
        {
            try
            {
                return await _repository.SearchAsync(
                    foodName,
                    minPrice ?? 0,
                    isAvailable);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving filtered place foods. "
                    + ex.Message, ex);
            }
        }

        public async Task<PlaceFoodDuyLd?> GetByIdAsync(long id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving place food. " + ex.Message, ex);
            }
        }

        public async Task<int> UpdateAsync(PlaceFoodDuyLd placeFood)
        {
            try
            {
                return await _repository.UpdateAsync(placeFood);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating place food. " + ex.Message, ex);
            }
        }
    }
}
