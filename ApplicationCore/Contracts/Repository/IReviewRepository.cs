using ApplicationCore.Entities;
namespace ApplicationCore.Contracts.Repository;

public interface IReviewRepository
{
    Task<Review> GetByIdAsync(int movieId, int userId);
    Task<IEnumerable<Review>> GetAllAsync();
    Task<IEnumerable<Review>> GetReviewsByMovieIdAsync(int movieId);
}
