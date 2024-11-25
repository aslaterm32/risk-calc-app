using System.ComponentModel.DataAnnotations;

namespace risk_calc_app.Models
{
    public class StockItem
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

        //Relationships
        public PortfolioItem Portfolio { get; set; }
    }
}
