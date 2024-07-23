using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class MovieCastRepository : IMovieCastRepository
    {
        private readonly MovieShopDbContext _dbContext;

        public MovieCastRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MovieCast> GetByIdAsync(int movieId, int castId)
        {
            return await _dbContext.MovieCasts
                .FirstOrDefaultAsync(mc => mc.MovieId == movieId && mc.CastId == castId);
        }

        public async Task<IEnumerable<MovieCast>> GetAllAsync()
        {
            return await _dbContext.MovieCasts.ToListAsync();
        }

        public async Task<IEnumerable<MovieCast>> GetByMovieIdAsync(int movieId)
        {
            return await _dbContext.MovieCasts
                .Where(mc => mc.MovieId == movieId)
                .Include(mc => mc.Cast)
                .ToListAsync();
        }

        public async Task AddAsync(MovieCast movieCast)
        {
            await _dbContext.MovieCasts.AddAsync(movieCast);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(MovieCast movieCast)
        {
            _dbContext.MovieCasts.Update(movieCast);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int movieId, int castId)
        {
            var movieCast = await _dbContext.MovieCasts
                .FirstOrDefaultAsync(mc => mc.MovieId == movieId && mc.CastId == castId);
            if (movieCast != null)
            {
                _dbContext.MovieCasts.Remove(movieCast);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}