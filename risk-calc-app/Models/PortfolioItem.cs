using System.ComponentModel.DataAnnotations;

namespace risk_calc_app.Models
{
    public class PortfolioItem
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        public decimal? Volatility { get; set; }

        //Relationships
        public ICollection<StockItem> Stocks { get; set; } = new List<StockItem>();
    }
}
