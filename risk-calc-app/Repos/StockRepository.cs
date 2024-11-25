using risk_calc_app.Data;
using risk_calc_app.Models;
using risk_calc_app.Interfaces;
using Microsoft.EntityFrameworkCore;
using risk_calc_app.DTOs.Stock;

namespace risk_calc_app.Repos
{
    public class StockRepository : IStockRepository
    {
        private readonly RiskCalcAppDbContext _context;

        public StockRepository(RiskCalcAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StockItem>> GetAllStocksAsync()
        {
            var stocks = await _context.StockItems.ToListAsync();
            return stocks;
        }

        public async Task<StockItem?> GetStockByIdAsync(int id)
        {
            var stock = await _context.StockItems.FirstOrDefaultAsync(i => i.Id == id);
            return stock;
        }
         
        public async Task<StockItem?> CreateStockAsync(StockItem stock)
        {
            await _context.StockItems.AddAsync(stock);
            await _context.SaveChangesAsync();

            return stock;
        }

        public async Task<StockItem> UpdateStockByIdAsync(int id, StockItem stock)
        {
            var stockForUpdate = await _context.StockItems.FirstOrDefaultAsync(i => i.Id == id);

            if (stockForUpdate == null)
            {
                return null;
            }

            stockForUpdate.Name = stock.Name;
            stockForUpdate.Ticker = stock.Ticker;
            stockForUpdate.Weighting = stock.Weighting;

            await _context.SaveChangesAsync();

            return stockForUpdate;
        }

        public async Task<StockItem?> DeleteStockByIdAsync(int id)
        {
            var stockForDelete = await _context.StockItems.FirstOrDefaultAsync(i => i.Id == id);

            if (stockForDelete == null)
            {
                return null;
            }

            _context.StockItems.Remove(stockForDelete);
            await _context.SaveChangesAsync();

            return stockForDelete;
        }

        public Task<bool> StockExists(int id)
        {
            return _context.StockItems.AnyAsync(i => i.Id == id);
        }
    }
}
