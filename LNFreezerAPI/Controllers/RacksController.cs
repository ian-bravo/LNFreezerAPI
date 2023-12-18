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
    public async Task<ActionResult<PaginatedList<Rack>>> Get([FromQuery] int? rackNum, [FromQuery] int? freezerId, [FromQuery] int? pageIndex, [FromQuery] int? pageSize)    
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

      // Pagination
      if (pageIndex.HasValue && pageSize.HasValue)
      {
        int pageNumber = pageIndex.Value > 0 ? pageIndex.Value : 1;
        int itemsPerPage = pageSize.Value > 0 ? pageSize.Value : 2;

        var paginatedList = await PaginatedList<Rack>.CreateAsync(query, pageNumber, itemsPerPage);

        return Ok(paginatedList);
      }

      // If no pagination parameters provided, return the entire list
      var allRacks = await query.ToListAsync();
      return Ok(allRacks);
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

    //PUT: api/racks/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Rack rack)
    {
      if (id != rack.RackId)
      {
        return BadRequest();
      }

      _db.Racks.Update(rack);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!RackExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    private bool RackExists(int id)
    {
      return _db.Racks.Any(entry => entry.RackId == id);
    }

    //DELETE: api/racks/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRack(int id)
    {
      Rack rack = await _db.Racks.FindAsync(id);
      if (rack == null)
      {
        return NotFound();
      }

      _db.Racks.Remove(rack);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}