using ApplicationCore.Models;
namespace ApplicationCore.Contracts.Services
{
    public interface ICastService
    {
        Task<IEnumerable<CastModel>> GetAllCastsAsync();
        Task<IEnumerable<CastModel>> GetCastsByMovieIdAsync(int movieId);
        Task DeleteCastAsync(int id);
    }
}