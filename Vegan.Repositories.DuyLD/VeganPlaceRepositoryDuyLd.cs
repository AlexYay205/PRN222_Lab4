using Microsoft.EntityFrameworkCore;
using Vegan.Entities.DuyLD.Models;
using Vegan.Repositories.DuyLD.Base;

namespace Vegan.Repositories.DuyLD
{
    public class VeganPlaceRepositoryDuyLd : GenericRepository<VeganPlaceDuyLd>
    {
        public VeganPlaceRepositoryDuyLd()
        {
            _context ??= new VeganDBContext();
        }

        public VeganPlaceRepositoryDuyLd(VeganDBContext context)
        {
            _context = context;
        }

        public new async Task<List<VeganPlaceDuyLd>> GetAllAsync()
        {
            return await _context.VeganPlaceDuyLds
                .Include(p => p.PlaceFoodDuyLds)
                .OrderBy(p => p.VeganPlaceDuyLdid)
                .ToListAsync();
        }

        public async Task<VeganPlaceDuyLd?> GetByIdAsync(long id)
        {
            return await _context.VeganPlaceDuyLds
                .Include(p => p.PlaceFoodDuyLds)
                .FirstOrDefaultAsync(p => p.VeganPlaceDuyLdid == id);
        }

        public async Task<List<VeganPlaceDuyLd>> SearchAsync(string? placeName, string? categoryName, bool? isActive)
        {
            var query = _context.VeganPlaceDuyLds
                .Include(p => p.PlaceFoodDuyLds)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(placeName))
            {
                query = query.Where(p => p.PlaceName.Contains(placeName));
            }

            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                query = query.Where(p => p.CategoryName.Contains(categoryName));
            }

            if (isActive.HasValue)
            {
                query = query.Where(p => p.IsActive == isActive.Value);
            }

            return await query
                .OrderBy(p => p.VeganPlaceDuyLdid)
                .ToListAsync();
        }
    }
}
