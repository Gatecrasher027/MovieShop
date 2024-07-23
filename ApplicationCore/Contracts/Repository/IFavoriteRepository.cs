using ApplicationCore.Entities;
namespace ApplicationCore.Contracts.Repository;

public interface IFavoriteRepository
{
    Task<Favorite> GetByIdAsync(int movieId, int userId);
    Task<IEnumerable<Favorite>> GetAllAsync();
    Task<IEnumerable<Favorite>> GetFavoritesByUserIdAsync(int userId);
}