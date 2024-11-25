using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace risk_calc_app.Migrations
{
    /// <inheritdoc />
    public partial class AddedStocksRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "PortfolioItems");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PortfolioItems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Volatility",
                table: "PortfolioItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "StockItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ticker = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Weighting = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockItems_PortfolioItems_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "PortfolioItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_PortfolioId",
                table: "StockItems",
                column: "PortfolioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockItems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PortfolioItems");

            migrationBuilder.DropColumn(
                name: "Volatility",
                table: "PortfolioItems");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "PortfolioItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
