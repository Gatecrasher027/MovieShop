using ApplicationCore.Entities;
namespace ApplicationCore.Contracts.Repository
{
    public interface IMovieRepository
    {
        Task<Movie> GetByIdAsync(int id);
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<IEnumerable<Movie>> GetHighestGrossingMoviesAsync();
    }
}