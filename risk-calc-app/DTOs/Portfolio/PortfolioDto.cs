using risk_calc_app.Models;
using System.ComponentModel.DataAnnotations;
using risk_calc_app.DTOs.Stock;

namespace risk_calc_app.DTOs.Portfolio
{
    public class PortfolioDto
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public decimal? Volatility { get; set; }

        public List<StockDto>? Stocks { get; set; }
    }
}
