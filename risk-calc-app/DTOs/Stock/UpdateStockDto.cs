using System.ComponentModel.DataAnnotations;

namespace risk_calc_app.DTOs.Stock
{
    public class UpdateStockDto
    {
        public string Name { get; set; }
        [StringLength(5)]
        public string Ticker { get; set; }
        public decimal Weighting { get; set; }
    }
}
