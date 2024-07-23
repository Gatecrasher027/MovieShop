using ApplicationCore.Entities;
namespace ApplicationCore.Contracts.Repository
{
    public interface IMovieCastRepository
    {
        Task<MovieCast> GetByIdAsync(int movieId, int castId);
        Task<IEnumerable<MovieCast>> GetAllAsync();
        Task<IEnumerable<MovieCast>> GetByMovieIdAsync(int movieId);
        Task AddAsync(MovieCast movieCast);
        Task UpdateAsync(MovieCast movieCast);
        Task DeleteAsync(int movieId, int castId);
    }
}