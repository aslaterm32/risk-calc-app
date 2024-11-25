using risk_calc_app.DTOs.Stock;
using risk_calc_app.Models;

namespace risk_calc_app.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this StockItem stock)
        {
            return new StockDto
            {
                Id = stock.Id,
                PortfolioId = stock.PortfolioId,
                Name = stock.Name,
                Ticker = stock.Ticker,
                Weighting = stock.Weighting
            };
        }

        public static StockItem ToStockFromStockDto(this StockDto stockDto)
        {
            return new StockItem
            {
                Id = stockDto.Id,
                PortfolioId = stockDto.PortfolioId,
                Name = stockDto.Name,
                Ticker = stockDto.Ticker,
                Weighting = stockDto.Weighting
            };
        }
    }
}
