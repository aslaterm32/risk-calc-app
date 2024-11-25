using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using risk_calc_app.Data.Services;
using risk_calc_app.Models;

namespace risk_calc_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {

        private readonly PortfoliosService _portfoliosService;

        public PortfolioController(PortfoliosService portfoliosService)
        {
            _portfoliosService = portfoliosService;
        }

        //GET api/portfolios
        [HttpGet]
        public ActionResult<IEnumerable<PortfolioItem>> Get()
        {
            try
            {
                var portfolios = _portfoliosService.GetAllPortfolios();
                return Ok(portfolios);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<PortfolioItem> Get(int id)
        {
            try
            {
                var portfolioItem = _portfoliosService.GetPortfolioById(id);
                return Ok(portfolioItem);
            } catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        //POST api/portfolios
        [HttpPost]
        public ActionResult Post([FromBody] PortfolioItem portfolioItem)
        {
            try
            {
                _portfoliosService.AddPortfolios(portfolioItem);
                return CreatedAtAction(nameof(Get), new { id = portfolioItem.Id }, portfolioItem);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //PUT api/portfolios
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PortfolioItem portfolioItem)
        {

            try
            {
                _portfoliosService.UpdatePortfolioById(id, portfolioItem);
                return NoContent();

            } catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        //DELETE api/portfolios
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _portfoliosService.DeletePortfolioById(id);
                return NoContent();
            } catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
