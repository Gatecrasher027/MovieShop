using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly MovieShopDbContext _dbContext;

        public FavoriteRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Favorite> GetByIdAsync(int movieId, int userId)
        {
            return await _dbContext.Favorites
                .FirstOrDefaultAsync(f => f.MovieId == movieId && f.UserId == userId);
        }

        public async Task<IEnumerable<Favorite>> GetAllAsync()
        {
            return await _dbContext.Favorites.ToListAsync();
        }

        public async Task<IEnumerable<Favorite>> GetFavoritesByUserIdAsync(int userId)
        {
            return await _dbContext.Favorites
                .Where(f => f.UserId == userId)
                .Include(f => f.Movie)
                .ToListAsync();
        }

        public async Task AddAsync(Favorite favorite)
        {
            await _dbContext.Favorites.AddAsync(favorite);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int movieId, int userId)
        {
            var favorite = await _dbContext.Favorites
                .FirstOrDefaultAsync(f => f.MovieId == movieId && f.UserId == userId);
            if (favorite != null)
            {
                _dbContext.Favorites.Remove(favorite);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}