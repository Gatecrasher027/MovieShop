using ApplicationCore.Entities;
namespace ApplicationCore.Contracts.Repository;

public interface IPurchaseRepository
{
    Task<Purchase> GetByIdAsync(int movieId, int userId);
    Task<IEnumerable<Purchase>> GetAllAsync();
    Task<IEnumerable<Purchase>> GetPurchasesByUserIdAsync(int userId);
}
