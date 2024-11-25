using System.ComponentModel.DataAnnotations;

namespace risk_calc_app.DTOs.Portfolio
{
    public class UpdatePortfolioDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal? Volatility { get; set; }
    }
}
