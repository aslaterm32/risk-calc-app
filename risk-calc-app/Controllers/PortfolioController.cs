using Microsoft.AspNetCore.Mvc;
using risk_calc_app.Data;
using risk_calc_app.DTOs.Portfolio;
using risk_calc_app.Interfaces;
using risk_calc_app.Models;
using risk_calc_app.Mappers;

namespace risk_calc_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {

        private readonly RiskCalcAppDbContext _context;
        private readonly IPortfolioRepository _portfolioRepo;

        public PortfolioController(RiskCalcAppDbContext context, IPortfolioRepository portfolioRepo)
        {
            _portfolioRepo = portfolioRepo;
            _context = context;
        }

        //GET api/portfolios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PortfolioDto>>> Get()
        {
                var portfolios = await _portfolioRepo.GetAllPortfoliosAsync();
                return Ok(portfolios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PortfolioItem>> GetById(int id)
        {
                var portfolioItem = await _portfolioRepo.GetPortfolioByIdAsync(id);
                return Ok(portfolioItem);
        }

        //POST api/portfolios
        [HttpPost]
        public async Task<ActionResult<PortfolioItem>> Create([FromBody] CreatePortfolioDto portfolioDto)
        {
            var portfolio = portfolioDto.ToPortfolioFromCreatePortfolioDto();
            await _portfolioRepo.CreatePortfolioAsync(portfolio);

            return CreatedAtAction(nameof(GetById), new { id = portfolio.Id }, portfolio.ToPortfolioDto());
        }

        //PUT api/portfolios
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody] UpdatePortfolioDto portfolioDto)
        {
              var portfolio = portfolioDto.ToPortfolioFromUpdatePortfolioDto();   
             await _portfolioRepo.UpdatePortfolioByIdAsync(id, portfolio);
             return NoContent();
        }

        //DELETE api/portfolios
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
                await _portfolioRepo.DeletePortfolioByIdAsync(id);
                return NoContent();
        }
    }
}
