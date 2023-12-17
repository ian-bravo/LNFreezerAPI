using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNFreezerApi.Models;

namespace LNFreezerApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SpecimensController : ControllerBase
  {
    private readonly LNFreezerApiContext _db;

    public SpecimensController(LNFreezerApiContext db)
    {
      _db = db;
    }

    //GET: api/specimens
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Specimen>>> Get([FromQuery] int? specimenNum, string cohort, [FromQuery] int? nHPNum, [FromQuery] int? date, string tissue, string quantity, [FromQuery] int? boxId)
    {
      IQueryable<Specimen> query = _db.Specimens.AsQueryable();

      if (specimenNum.HasValue)
      {
        query = query.Where(entry => entry.SpecimenNum == specimenNum.Value);
      }

      if (cohort != null)
      {
        query = query.Where(entry => entry.Cohort == cohort);
      }

      if (nHPNum.HasValue)
      {
        query = query.Where(entry => entry.NHPNum == nHPNum.Value);
      }

      if (date.HasValue)
      {
        query = query.Where(entry => entry.Date == date.Value);
      }

      if (tissue != null)
      {
        query = query.Where(entry => entry.Tissue == tissue);
      }

      if (quantity != null)
      {
        query = query.Where(entry => entry.Quantity == quantity);
      }

      return await query.ToListAsync();
    }

    //GET: api/specimens/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Specimen>> GetSpecimen(int id)
    {
      Specimen specimen = await _db.Specimens.FindAsync(id);

      if (specimen == null)
      {
        return NotFound();
      }

      return specimen;
    }

  }
}