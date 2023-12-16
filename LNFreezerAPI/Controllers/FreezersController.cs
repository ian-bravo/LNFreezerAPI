using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNFreezerApi.Models;

namespace LNFreezerApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FreezersController : ControllerBase
  {
    private readonly LNFreezerApiContext _db;

    public FreezersController(LNFreezerApiContext db)
    {
      _db = db;
    }

    //GET: api/freezers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Freezer>>> Get()
    {
      IQueryable<Freezer> query = _db.Freezers.AsQueryable();

      return await _db.Freezers.ToListAsync();
    }

    //GET: api/freezers/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Freezer>> GetFreezer(int id)
    {
      Freezer freezer = await _db.Freezers.FindAsync(id);

      if (freezer == null)
      {
        return NotFound();
      }

      return freezer;
    }

    //POST: api/freezers
    [HttpPost]
    public async Task<ActionResult<Freezer>> Post(Freezer freezer)
    {
      _db.Freezers.Add(freezer);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetFreezer), new { id = freezer.FreezerId }, freezer);
    }
  }
}