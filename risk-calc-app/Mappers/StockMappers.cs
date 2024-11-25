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

        public static StockItem ToStockFromCreateStockDto(this CreateStockDto stockDto, int portfolioId)
        {
            return new StockItem
            {
                PortfolioId = portfolioId,
                Name = stockDto.Name,
                Ticker = stockDto.Ticker,
                Weighting = stockDto.Weighting
            };
        }

        public static StockItem ToStockFromUpdateStockDto(this UpdateStockDto stockDto)
        {
            return new StockItem
            {
                Name = stockDto.Name,
                Ticker = stockDto.Ticker,
                Weighting = stockDto.Weighting
            };
        }
    }
}
