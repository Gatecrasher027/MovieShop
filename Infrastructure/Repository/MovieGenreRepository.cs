using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class MovieGenreRepository : IMovieGenreRepository
    {
        private readonly MovieShopDbContext _dbContext;

        public MovieGenreRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MovieGenre> GetByIdAsync(int movieId, int genreId)
        {
            return await _dbContext.MovieGenres
                .FirstOrDefaultAsync(mg => mg.MovieId == movieId && mg.GenreId == genreId);
        }

        public async Task<IEnumerable<MovieGenre>> GetAllAsync()
        {
            return await _dbContext.MovieGenres.ToListAsync();
        }

        public async Task<IEnumerable<MovieGenre>> GetByMovieIdAsync(int movieId)
        {
            return await _dbContext.MovieGenres
                .Where(mg => mg.MovieId == movieId)
                .Include(mg => mg.Genre)
                .ToListAsync();
        }

        public async Task AddAsync(MovieGenre movieGenre)
        {
            await _dbContext.MovieGenres.AddAsync(movieGenre);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(MovieGenre movieGenre)
        {
            _dbContext.MovieGenres.Update(movieGenre);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int movieId, int genreId)
        {
            var movieGenre = await _dbContext.MovieGenres
                .FirstOrDefaultAsync(mg => mg.MovieId == movieId && mg.GenreId == genreId);
            if (movieGenre != null)
            {
                _dbContext.MovieGenres.Remove(movieGenre);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}