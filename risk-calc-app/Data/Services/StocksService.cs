using Microsoft.EntityFrameworkCore;
using risk_calc_app.Models;

namespace risk_calc_app.Data.Services

{
    public class StocksService
    {

        private RiskCalcAppDbContext _riskCalcAppDbContext;
        public StocksService(RiskCalcAppDbContext context)
        {
            _riskCalcAppDbContext = context;
        }

        //CREATE
        public void AddStocks(StockItem stockItem)
        {
            var portfolio = _riskCalcAppDbContext.PortfolioItems.FirstOrDefault(i => i.Id ==  stockItem.PortfolioId);

            if (portfolio == null)
            {
                throw new Exception("PortfolioId not found.");
            }

            stockItem.PortfolioId = portfolio.Id;
            stockItem.Portfolio = portfolio;

            _riskCalcAppDbContext.StockItems.Add(stockItem);
            _riskCalcAppDbContext.SaveChanges();
        }

        //READ
        public List<StockItem> GetAllStocks()
        {
            var stocks = _riskCalcAppDbContext.StockItems.ToList();
            return stocks;
        }

        public StockItem GetStockById(int id)
        {
            var stockItem = _riskCalcAppDbContext.StockItems.FirstOrDefault(i => i.Id == id);

            if (stockItem == null)
            {
                throw new Exception("Stock not found.");
            }

            return stockItem;
        }

        //UPDATE
        public StockItem UpdateStockById(int id, StockItem stockItem)
        {
            if (id != stockItem.Id)
            {
                throw new Exception("Id provided does not match stockId.");
            }

            var stockItemForUpdate = _riskCalcAppDbContext.StockItems.FirstOrDefault(i => i.Id == id);

            if (stockItemForUpdate == null)
            {
                throw new Exception("Stock not found.");
            }

            stockItemForUpdate.PortfolioId = stockItem.PortfolioId;
            stockItemForUpdate.Name = stockItem.Name;
            stockItemForUpdate.Ticker = stockItem.Ticker;

            stockItemForUpdate.Portfolio = _riskCalcAppDbContext.PortfolioItems.FirstOrDefault(predicate: i => i.Id == stockItem.PortfolioId);

            _riskCalcAppDbContext.SaveChanges();

            return stockItemForUpdate;
        }

        //DELETE
        public void DeletestockById(int id)
        {
            var stockItemForDelete = _riskCalcAppDbContext.StockItems.FirstOrDefault(i => i.Id == id);

            if (stockItemForDelete == null)
            {
                throw new Exception("Stock not found.");
            }

            _riskCalcAppDbContext.StockItems.Remove(stockItemForDelete);
        }

    }
}
