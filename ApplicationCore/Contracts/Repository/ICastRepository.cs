using ApplicationCore.Entities;
namespace ApplicationCore.Contracts.Repository
{
    public interface ICastRepository
    {
        Task<Cast> GetByIdAsync(int id);
        Task<IEnumerable<Cast>> GetAllAsync();
        Task<IEnumerable<Cast>> GetCastsByMovieIdAsync(int movieId);
        Task AddAsync(Cast cast);
        Task UpdateAsync(Cast cast);
        Task DeleteAsync(int id);
    }
}