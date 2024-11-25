using Microsoft.AspNetCore.Mvc;
using risk_calc_app.Data;
using risk_calc_app.DTOs.Stock;
using risk_calc_app.Interfaces;
using risk_calc_app.Mappers;
using risk_calc_app.Models;
using risk_calc_app.DTOs;

namespace risk_calc_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly RiskCalcAppDbContext _context;
        private readonly IStockRepository _stockRepo;
        private readonly IPortfolioRepository _portfolioRepo;

        public StockController(RiskCalcAppDbContext context, IStockRepository stockRepo, IPortfolioRepository postfolioRepo)
        {
            _stockRepo = stockRepo;
            _portfolioRepo = postfolioRepo;
            _context = context;
        }

        //GET api/stocks
        [HttpGet]
        public async Task<ActionResult<List<StockDto>>> Get()
        {
            var stocks = await _stockRepo.GetAllStocksAsync();
            var stockDtos = stocks.Select(i => i.ToStockDto()).ToList();
            return Ok(stockDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StockDto>> GetById(int id)
        {
            var stockItem = await _stockRepo.GetStockByIdAsync(id);

            if (stockItem == null)
            {
                return NotFound();
            }

            return Ok(stockItem.ToStockDto());
        }

        //POST api/stocks
        [HttpPost("{portfolioId}")]
        public async Task<ActionResult<StockItem>> Create([FromRoute] int portfolioId, [FromBody] CreateStockDto createStockDto)
        {
            if(!await _portfolioRepo.PortfolioExists(portfolioId))
            {
                return BadRequest("Stock does not exist.");
            }

            var stock = createStockDto.ToStockFromCreateStockDto(portfolioId);

            await _stockRepo.CreateStockAsync(stock);
            return CreatedAtAction(nameof(GetById), new {id =  stock.Id}, stock.ToStockDto());
        }

        //PUT api/stocks
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody] UpdateStockDto updateStockDto)
        {
            if(!await _stockRepo.StockExists(id))
            {
                return NotFound();
            }
            var stock = updateStockDto.ToStockFromUpdateStockDto();
            await _stockRepo.UpdateStockByIdAsync(id, stock);
            return Ok(stock.ToStockDto());
        }

        //DELETE api/stocks
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!await _stockRepo.StockExists(id))
            {
                return NotFound();
            }

            var stock = await _stockRepo.DeleteStockByIdAsync(id);
            return Ok(stock);
        }
    }
}
