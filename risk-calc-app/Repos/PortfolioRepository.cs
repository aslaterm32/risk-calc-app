using risk_calc_app.Data;
using risk_calc_app.Interfaces;
using risk_calc_app.Models;
using Microsoft.EntityFrameworkCore;
using risk_calc_app.DTOs.Portfolio;
using risk_calc_app.Mappers;

namespace risk_calc_app.Repos
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly RiskCalcAppDbContext _context;

        public PortfolioRepository(RiskCalcAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PortfolioItem>> GetAllPortfoliosAsync()
        {
            var portfolios = await _context.PortfolioItems.Include(i => i.Stocks).ToListAsync();
            return portfolios;
        }

        public async Task<PortfolioItem?> GetPortfolioByIdAsync(int id)
        {
            var portfolio = await _context.PortfolioItems.Include(i => i.Stocks).FirstOrDefaultAsync(i => i.Id == id);

            if (portfolio == null)
            {
                return null;
            }

            return portfolio;
        }

        public async Task<PortfolioItem?> CreatePortfolioAsync(PortfolioItem portfolio)
        {
            await _context.PortfolioItems.AddAsync(portfolio);
            await _context.SaveChangesAsync();

            return portfolio;
        }

        public async Task<PortfolioItem?> UpdatePortfolioByIdAsync(int id, PortfolioItem portfolio)
        {
            var portfolioForUpdate = await _context.PortfolioItems.FirstOrDefaultAsync(i => i.Id == id);

            if (portfolioForUpdate == null)
            {
                return null;
            }

            portfolioForUpdate.Name = portfolio.Name;
            portfolioForUpdate.Volatility = portfolio.Volatility;

            await _context.SaveChangesAsync();

            return portfolioForUpdate;

        }

        public async Task<PortfolioItem?> DeletePortfolioByIdAsync(int id)
        {
            var portfolioForDelete = await _context.PortfolioItems.FirstOrDefaultAsync(i => i.Id == id);

            if (portfolioForDelete == null)
            {
                return null;
            }

            _context.PortfolioItems.Remove(portfolioForDelete);
            await _context.SaveChangesAsync();

            return portfolioForDelete;
        }

        public Task<bool> PortfolioExists(int id)
        {
            return _context.PortfolioItems.AnyAsync(i => i.Id == id);
        }

    }
}
