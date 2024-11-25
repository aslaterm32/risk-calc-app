using risk_calc_app.Models;
using System.ComponentModel.DataAnnotations;

namespace risk_calc_app.DTOs.Stock
{
    public class StockDto
    {
        public int Id { get; set; }
        [Required]
        public int PortfolioId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, StringLength(5)]
        public string Ticker { get; set; }
        [Required]
        public decimal Weighting { get; set; }
    }
}
