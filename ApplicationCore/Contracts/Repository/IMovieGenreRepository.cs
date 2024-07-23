using ApplicationCore.Entities;
namespace ApplicationCore.Contracts.Repository;

public interface IMovieGenreRepository
{
    Task<MovieGenre> GetByIdAsync(int movieId, int genreId);
    Task<IEnumerable<MovieGenre>> GetAllAsync();
    Task<IEnumerable<MovieGenre>> GetByMovieIdAsync(int movieId);
    Task AddAsync(MovieGenre movieGenre);
    Task UpdateAsync(MovieGenre movieGenre);
    Task DeleteAsync(int movieId, int genreId);
}