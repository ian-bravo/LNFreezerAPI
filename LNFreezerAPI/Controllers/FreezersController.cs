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
    public async Task<ActionResult<PaginatedList<Freezer>>> Get([FromQuery] int? freezerNum, [FromQuery] int? pageIndex, [FromQuery] int? pageSize)
    {
      IQueryable<Freezer> query = _db.Freezers.AsQueryable();

      if (freezerNum.HasValue)
      {
        query = query.Where(entry => entry.FreezerNum == freezerNum.Value);
      }

      // Pagination
      if (pageIndex.HasValue && pageSize.HasValue)
      {
        int pageNumber = pageIndex.Value > 0 ? pageIndex.Value : 1;
        int itemsPerPage = pageSize.Value > 0 ? pageSize.Value : 2;

        var paginatedList = await PaginatedList<Freezer>.CreateAsync(query, pageNumber, itemsPerPage);

        return Ok(paginatedList);
      }

      // If no pagination parameters provided, return the entire list
      var allFreezers = await query.ToListAsync();
      return Ok(allFreezers);
    }
    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<Freezer>>> Get()
    // {
    //   IQueryable<Freezer> query = _db.Freezers.AsQueryable();

    //   return await _db.Freezers.ToListAsync();
    // }

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

    //PUT: api/freezers/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Freezer freezer)
    {
      if (id != freezer.FreezerId)
      {
        return BadRequest();
      }

      _db.Freezers.Update(freezer);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!FreezerExists(id))
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

    private bool FreezerExists(int id)
    {
      return _db.Freezers.Any(entry => entry.FreezerId == id);
    }
    
    //DELETE: api/freezers/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFreezer(int id)
    {
      Freezer freezer = await _db.Freezers.FindAsync(id);
      if (freezer == null)
      {
        return NotFound();
      }

      _db.Freezers.Remove(freezer);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}