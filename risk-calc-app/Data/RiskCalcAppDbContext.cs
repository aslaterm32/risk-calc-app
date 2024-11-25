using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using risk_calc_app.Models;

namespace risk_calc_app.Data
{
    public class RiskCalcAppDbContext : DbContext
    {
        public RiskCalcAppDbContext(DbContextOptions<RiskCalcAppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<StockItem>()
                .HasOne(s => s.Portfolio)
                .WithMany(p => p.Stocks)
                .HasForeignKey(s => s.PortfolioId)
                .IsRequired();
        }

        public DbSet<PortfolioItem> PortfolioItems { get; set; }

        public DbSet<StockItem> StockItems { get; set; }

    }
}
