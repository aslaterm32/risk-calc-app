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

            if (stock == null)
            {
                return null;
            }

            return stock;
        }
         
        public async Task<StockItem?> CreateStockAsync(StockDto stockDto)
        {
            var stock = new StockItem()
            {
                Id = stockDto.Id,
                PortfolioId = stockDto.PortfolioId,
                Name = stockDto.Name,
                Ticker = stockDto.Ticker,
                Weighting = stockDto.Weighting
            };

            await _context.StockItems.AddAsync(stock);
            await _context.SaveChangesAsync();

            return stock;
        }

        public async Task<StockItem> UpdateStockByIdAsync(int id, StockDto stockDto)
        {
            var stockForUpdate = await _context.StockItems.FirstOrDefaultAsync(i => i.Id == id);

            if (stockForUpdate == null)
            {
                return null;
            }

            stockForUpdate.Name = stockDto.Name;
            stockForUpdate.Ticker = stockDto.Ticker;
            stockForUpdate.Weighting = stockDto.Weighting;

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
    }
}
