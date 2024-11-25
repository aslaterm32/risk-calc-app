using risk_calc_app.Models;
using System.ComponentModel.DataAnnotations;

namespace risk_calc_app.DTOs.Portfolio
{
    public class CreatePortfolioDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Volatility { get; set; }
    }
}
