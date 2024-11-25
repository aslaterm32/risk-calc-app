using Microsoft.EntityFrameworkCore;
using risk_calc_app.Models;

namespace risk_calc_app.Data.Services

{
    public class PortfoliosService
    {

        private RiskCalcAppDbContext _riskCalcAppDbContext;
        public PortfoliosService(RiskCalcAppDbContext context)
        {
            _riskCalcAppDbContext = context;
        }

        //CREATE
        public void AddPortfolios(PortfolioItem portfolioItem)
        {
            _riskCalcAppDbContext.PortfolioItems.Add(portfolioItem);
            _riskCalcAppDbContext.SaveChanges();
        }

        //READ
        public List<PortfolioItem> GetAllPortfolios()
        {
            var portfolios = _riskCalcAppDbContext.PortfolioItems.ToList();
            return portfolios;
        }

        public PortfolioItem GetPortfolioById(int id)
        {
            var portfolioItem = _riskCalcAppDbContext.PortfolioItems.FirstOrDefault(i => i.Id == id);

            if (portfolioItem == null)
            {
                throw new Exception("Portfolio not found.");
            }

            return portfolioItem;
        }

        //UPDATE
        public PortfolioItem UpdatePortfolioById(int id, PortfolioItem portfolioItem)
        {
            if (id != portfolioItem.Id)
            {
                throw new Exception("Id provided does not match portfolioId.");
            }

            var portfolioItemForUpdate = _riskCalcAppDbContext.PortfolioItems.FirstOrDefault(i => i.Id == id);

            if (portfolioItemForUpdate == null)
            {
                throw new Exception("Portfolio not found.");
            }

            portfolioItemForUpdate.Name = portfolioItem.Name;
            portfolioItemForUpdate.Volatility = portfolioItem.Volatility.HasValue ? portfolioItem.Volatility : null;

            _riskCalcAppDbContext.SaveChanges();

            return portfolioItemForUpdate;
        }

        //DELETE
        public void DeletePortfolioById(int id)
        {
            var portfolioItemForDelete = _riskCalcAppDbContext.PortfolioItems.FirstOrDefault(i => i.Id == id);

            if (portfolioItemForDelete == null)
            {
                throw new Exception("Portfolio not found.");
            }

            _riskCalcAppDbContext.PortfolioItems.Remove(portfolioItemForDelete);
        }

    }
}
