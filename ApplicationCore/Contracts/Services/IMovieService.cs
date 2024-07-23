using ApplicationCore.Models;
namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        Task<MovieDetailsModel> GetMovieDetailsAsync(int id);
        Task<IEnumerable<MovieCardModel>> GetTopGrossingMoviesAsync();
        Task<IEnumerable<MovieCardModel>> GetAllMoviesAsync();
    }
}

