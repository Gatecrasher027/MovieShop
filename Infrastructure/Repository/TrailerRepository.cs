using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class TrailerRepository : ITrailerRepository
    {
        private readonly MovieShopDbContext _dbContext;

        public TrailerRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Trailer> GetByIdAsync(int id)
        {
            return await _dbContext.Trailers.FindAsync(id);
        }

        public async Task<IEnumerable<Trailer>> GetAllAsync()
        {
            return await _dbContext.Trailers.ToListAsync();
        }

        public async Task<IEnumerable<Trailer>> GetByMovieIdAsync(int movieId)
        {
            return await _dbContext.Trailers.Where(t => t.MovieId == movieId).ToListAsync();
        }

        public async Task AddAsync(Trailer trailer)
        {
            await _dbContext.Trailers.AddAsync(trailer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Trailer trailer)
        {
            _dbContext.Trailers.Update(trailer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var trailer = await _dbContext.Trailers.FindAsync(id);
            if (trailer != null)
            {
                _dbContext.Trailers.Remove(trailer);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}