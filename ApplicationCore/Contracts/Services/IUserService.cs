using ApplicationCore.Models;
namespace ApplicationCore.Contracts.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByEmailAsync(string email);
        Task DeleteUserAsync(int id);
    }
}