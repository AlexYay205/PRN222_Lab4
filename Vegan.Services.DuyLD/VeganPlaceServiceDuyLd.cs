using Vegan.Entities.DuyLD.Models;
using Vegan.Repositories.DuyLD;

namespace Vegan.Services.DuyLD
{
    public class VeganPlaceServiceDuyLd : IVeganPlaceServiceDuyLd
    {
        public readonly VeganPlaceRepositoryDuyLd _repository;

        public VeganPlaceServiceDuyLd()
            => _repository ??= new VeganPlaceRepositoryDuyLd();

        public async Task<int> CreateAsync(VeganPlaceDuyLd veganPlace)
        {
            try
            {
                return await _repository.CreateAsync(veganPlace);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating vegan place. " + ex.Message, ex);
            }
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var veganPlace = await _repository.GetByIdAsync(id);

                if (veganPlace == null)
                {
                    throw new KeyNotFoundException($"Vegan place with ID {id} not found.");
                }

                return await _repository.RemoveAsync(veganPlace);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting vegan place. " + ex.Message, ex);
            }
        }

        public async Task<List<VeganPlaceDuyLd>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all vegan places. " + ex.Message, ex);
            }
        }

        public async Task<List<VeganPlaceDuyLd>> GetAllAsync(
            string? placeName,
            string? categoryName,
            bool? isActive)
        {
            try
            {
                return await _repository.SearchAsync(
                    placeName,
                    categoryName,
                    isActive);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving filtered vegan places. "
                    + ex.Message, ex);
            }
        }

        public async Task<VeganPlaceDuyLd?> GetByIdAsync(long id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving vegan place. " + ex.Message, ex);
            }
        }

        public async Task<int> UpdateAsync(VeganPlaceDuyLd veganPlace)
        {
            try
            {
                return await _repository.UpdateAsync(veganPlace);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating vegan place. " + ex.Message, ex);
            }
        }
    }
}
