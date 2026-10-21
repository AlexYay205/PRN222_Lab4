using Microsoft.EntityFrameworkCore;
using Vegan.Entities.DuyLD.Models;
using Vegan.Repositories.DuyLD.Base;

namespace Vegan.Repositories.DuyLD
{
    public class PlaceFoodRepositoryDuyLd : GenericRepository<PlaceFoodDuyLd>
    {
        public PlaceFoodRepositoryDuyLd()
        {
            _context ??= new VeganDBContext();
        }

        public PlaceFoodRepositoryDuyLd(VeganDBContext context)
        {
            _context = context;
        }

        public new async Task<List<PlaceFoodDuyLd>> GetAllAsync()
        {
            return await _context.PlaceFoodDuyLds
                .Include(f => f.VeganPlaceDuyLd)
                .ToListAsync();
        }

        public async Task<PlaceFoodDuyLd?> GetByIdAsync(long id)
        {
            return await _context.PlaceFoodDuyLds
                .Include(f => f.VeganPlaceDuyLd)
                .FirstOrDefaultAsync(f => f.PlaceFoodDuyLdid == id);
        }

        public async Task<List<PlaceFoodDuyLd>> SearchAsync(string foodName, decimal minPrice, bool? isAvailable)
        {
            return await _context.PlaceFoodDuyLds
                .Include(f => f.VeganPlaceDuyLd)
                .Where(f =>
                    (f.FoodName.Contains(foodName) || string.IsNullOrEmpty(foodName))
                    && (f.Price >= minPrice || minPrice == 0)
                    && (f.IsAvailable == isAvailable || isAvailable == null))
                .ToListAsync();
        }
    }
}
