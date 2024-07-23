using ApplicationCore.Entities;
namespace ApplicationCore.Contracts.Repository
{
    public interface ITrailerRepository
    {
        Task<Trailer> GetByIdAsync(int id);
        Task<IEnumerable<Trailer>> GetAllAsync();
        Task<IEnumerable<Trailer>> GetByMovieIdAsync(int movieId);
        Task AddAsync(Trailer trailer);
        Task UpdateAsync(Trailer trailer);
        Task DeleteAsync(int id);
    }
}