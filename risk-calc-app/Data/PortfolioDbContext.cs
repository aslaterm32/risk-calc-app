using Microsoft.EntityFrameworkCore;
using risk_calc_app.Models;

namespace risk_calc_app.Data

{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
        {
            
        }

        public DbSet<PortfolioItem> PortfolioItems { get; set; }

    }
}
