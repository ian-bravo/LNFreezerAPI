using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNFreezerApi.Models;

namespace LNFreezerApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RacksController : ControllerBase
  {
    private readonly LNFreezerApiContext _db;

    public RacksController(LNFreezerApiContext db)
    {
      _db = db;
    }

    //GET: api/racks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Rack>>> Get([FromQuery] int? rackNum, [FromQuery]  int? freezerId)
    {
      IQueryable<Rack> query = _db.Racks.AsQueryable();

      if (rackNum.HasValue)
      {
        query = query.Where(entry => entry.RackNum == rackNum.Value);
      }

      if (freezerId.HasValue)
      {
        query = query.Where(entry => entry.FreezerId == freezerId.Value);
      }

      return await query.ToListAsync();
    }

    //GET: api/racks/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Rack>> GetRack(int id)
    {
      Rack rack = await _db.Racks.FindAsync(id);

      if (rack == null)
      {
        return NotFound();
      }

      return rack;
    }

    //POST: api/racks
    [HttpPost]
    public async Task<ActionResult<Rack>> Post(Rack rack)
    {
      _db.Racks.Add(rack);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetRack), new { id = rack.RackId }, rack);
    }
  }
}