using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly MovieShopDbContext _dbContext;

        public PurchaseRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Purchase> GetByIdAsync(int movieId, int userId)
        {
            return await _dbContext.Purchases
                .FirstOrDefaultAsync(p => p.MovieId == movieId && p.UserId == userId);
        }

        public async Task<IEnumerable<Purchase>> GetAllAsync()
        {
            return await _dbContext.Purchases.ToListAsync();
        }

        public async Task<IEnumerable<Purchase>> GetPurchasesByUserIdAsync(int userId)
        {
            return await _dbContext.Purchases
                .Where(p => p.UserId == userId)
                .Include(p => p.Movie)
                .ToListAsync();
        }

        public async Task AddAsync(Purchase purchase)
        {
            await _dbContext.Purchases.AddAsync(purchase);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int movieId, int userId)
        {
            var purchase = await _dbContext.Purchases
                .FirstOrDefaultAsync(p => p.MovieId == movieId && p.UserId == userId);
            if (purchase != null)
            {
                _dbContext.Purchases.Remove(purchase);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}