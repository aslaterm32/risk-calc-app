using risk_calc_app.DTOs.Portfolio;
using risk_calc_app.Models;
using risk_calc_app.Mappers;
using risk_calc_app.DTOs.Stock;

namespace risk_calc_app.Mappers
{
    public static class PortfolioMapper
    {
        public static PortfolioDto ToPortfolioDto(this PortfolioItem portfolio)
        {
            return new PortfolioDto
            {
                Id = portfolio.Id,
                Name = portfolio.Name,
                Volatility = portfolio.Volatility,
                Stocks = portfolio.Stocks.Select(i => i.ToStockDto()).ToList()
            };
        }

        public static PortfolioItem ToPortfolioFromCreatePortfolioDto(this CreatePortfolioDto createPortfolioDto)
        {
            return new PortfolioItem
            {
                Id = createPortfolioDto.Id,
                Name = createPortfolioDto.Name,
                Volatility = createPortfolioDto.Volatility
            };
        }

        public static PortfolioItem ToPortfolioFromUpdatePortfolioDto(this UpdatePortfolioDto updatePortfolioDto)
        {
            return new PortfolioItem
            {
                Name = updatePortfolioDto.Name,
                Volatility = updatePortfolioDto.Volatility
            };
        }
    }
}
