using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using risk_calc_app.Data;
using risk_calc_app.Models;

namespace risk_calc_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {

        private readonly PortfolioDbContext _portfolioDbContext;

        public PortfolioController(PortfolioDbContext portfolioDbContext)
        {
            _portfolioDbContext = portfolioDbContext;
        }

        //GET api/portfolios
        [HttpGet]
        public ActionResult<IEnumerable<PortfolioItem>> Get()
        {
            var portfolios = _portfolioDbContext.PortfolioItems.ToList();
            return Ok(portfolios);
        }

        [HttpGet("{id}")]
        public ActionResult<PortfolioItem> Get(int id)
        {
            var portfolioItem = _portfolioDbContext.PortfolioItems.FirstOrDefault(x => x.Id == id); // TODO: call db

            if (portfolioItem == null)
            {
                return NotFound();
            }

            return Ok(portfolioItem);
        }

        //POST api/portfolios
        [HttpPost]
        public ActionResult Post([FromBody] PortfolioItem portfolioItem)
        {
            _portfolioDbContext.PortfolioItems.Add(portfolioItem);
            _portfolioDbContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = portfolioItem.Id }, portfolioItem);
        }

        //PUT api/portfolios
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PortfolioItem portfolioItem)
        {
            if (id != portfolioItem.Id)
            {
                return BadRequest();
            }

            var portfolioItemForUpdate = _portfolioDbContext.PortfolioItems.FirstOrDefault(x => x.Id == id);

            if (portfolioItemForUpdate == null)
            {
                return NotFound();
            }

            portfolioItemForUpdate.Id = portfolioItem.Id;
            portfolioItemForUpdate.OwnerId = portfolioItem.OwnerId;

            _portfolioDbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var portfolioItemForDelete = _portfolioDbContext.PortfolioItems.FirstOrDefault(x => x.Id == id);

            if (portfolioItemForDelete == null)
            {
                return NotFound();
            }

            _portfolioDbContext.PortfolioItems.Remove(portfolioItemForDelete);
            _portfolioDbContext.SaveChanges();

            return NoContent();
        }
    }
}
