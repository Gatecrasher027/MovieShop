using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CastRepository : ICastRepository
    {
        private readonly MovieShopDbContext _dbContext;

        public CastRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Cast> GetByIdAsync(int id)
        {
            return await _dbContext.Casts.FindAsync(id);
        }

        public async Task<IEnumerable<Cast>> GetAllAsync()
        {
            return await _dbContext.Casts.ToListAsync();
        }

        public async Task<IEnumerable<Cast>> GetCastsByMovieIdAsync(int movieId)
        {
            return await _dbContext.MovieCasts
                .Include(mc => mc.Cast)
                .Where(mc => mc.MovieId == movieId)
                .Select(mc => mc.Cast)
                .ToListAsync();
        }

        public async Task AddAsync(Cast cast)
        {
            await _dbContext.Casts.AddAsync(cast);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cast cast)
        {
            _dbContext.Casts.Update(cast);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cast = await _dbContext.Casts.FindAsync(id);
            if (cast != null)
            {
                _dbContext.Casts.Remove(cast);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}