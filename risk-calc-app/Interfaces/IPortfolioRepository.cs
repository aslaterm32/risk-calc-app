using risk_calc_app.DTOs.Portfolio;
using risk_calc_app.Models;

namespace risk_calc_app.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<List<Models.PortfolioItem>> GetAllPortfoliosAsync();
        Task<Models.PortfolioItem?> GetPortfolioByIdAsync(int id);
        Task<Models.PortfolioItem?> CreatePortfolioAsync(PortfolioItem portfolio);
        Task<Models.PortfolioItem?> UpdatePortfolioByIdAsync(int id, PortfolioItem portfolio);
        Task<Models.PortfolioItem?> DeletePortfolioByIdAsync(int id);
    }
}
