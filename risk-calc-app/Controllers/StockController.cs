using Microsoft.AspNetCore.Mvc;
using risk_calc_app.Data;
using risk_calc_app.DTOs.Stock;
using risk_calc_app.Interfaces;
using risk_calc_app.Models;

namespace risk_calc_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly RiskCalcAppDbContext _context;
        private readonly IStockRepository _stockRepo;

        public StockController(RiskCalcAppDbContext context, IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
            _context = context;
        }

        //GET api/stocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockItem>>> Get()
        {
            var stocks = await _stockRepo.GetAllStocksAsync();
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StockItem>> GetById(int id)
        {
            var stockItem = await _stockRepo.GetStockByIdAsync(id);
            return Ok(stockItem);
        }

        //POST api/stocks
        [HttpPost]
        public async Task<ActionResult<StockItem>> Create(StockDto stockDto)
        {
            await _stockRepo.CreateStockAsync(stockDto);

            return Ok(stockDto);
        }

        //PUT api/stocks
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] StockDto stockDto)
        {
            await _stockRepo.UpdateStockByIdAsync(id, stockDto);
            return NoContent();
        }

        //DELETE api/stocks
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _stockRepo.DeleteStockByIdAsync(id);
            return NoContent();
        }
    }
}
