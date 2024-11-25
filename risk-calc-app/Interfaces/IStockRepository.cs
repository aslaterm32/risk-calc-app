using risk_calc_app.DTOs.Stock;
using risk_calc_app.Models;

namespace risk_calc_app.Interfaces
{
    public interface IStockRepository
    {
        Task<List<StockItem>> GetAllStocksAsync();
        Task<StockItem?> GetStockByIdAsync(int id);
        Task<StockItem?> CreateStockAsync(StockItem stock);
        Task<StockItem?> UpdateStockByIdAsync(int id, StockItem stock);
        Task<StockItem?> DeleteStockByIdAsync(int id);
        Task<bool> StockExists(int id);
    }
}
