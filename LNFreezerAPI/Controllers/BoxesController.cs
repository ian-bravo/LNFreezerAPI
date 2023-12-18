using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LNFreezerApi.Models;

namespace LNFreezerApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BoxesController : ControllerBase
  {
    private readonly LNFreezerApiContext _db;

    public BoxesController(LNFreezerApiContext db)
    {
      _db = db;
    }

    //GET: api/boxes
    [HttpGet]
    public async Task<ActionResult<PaginatedList<Box>>> Get(string boxAlpha, [FromQuery] int? rackId, [FromQuery] int? pageIndex, [FromQuery] int? pageSize)
    {
      IQueryable<Box> query = _db.Boxes.AsQueryable();

      if (boxAlpha != null)
      {
        query = query.Where(entry => entry.BoxAlpha == boxAlpha);
      }

      if (rackId.HasValue)
      {
        query = query.Where(entry => entry.RackId == rackId.Value);
      }

      // Pagination
      if (pageIndex.HasValue && pageSize.HasValue)
      {
        int pageNumber = pageIndex.Value > 0 ? pageIndex.Value : 1;
        int itemsPerPage = pageSize.Value > 0 ? pageSize.Value : 2;

        var paginatedList = await PaginatedList<Box>.CreateAsync(query, pageNumber, itemsPerPage);

        return Ok(paginatedList);
      }

      // If no pagination parameters provided, return the entire list
      var allBoxes = await query.ToListAsync();
      return Ok(allBoxes);
    }

    //GET: api/boxes/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Box>> GetBox(int id)
    {
      Box box = await _db.Boxes.FindAsync(id);

      if (box == null)
      {
        return NotFound();
      }

      return box;
    }

    //POST: api/boxes
    [HttpPost]
    public async Task<ActionResult<Box>> Post(Box box)
    {
      _db.Boxes.Add(box);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetBox), new { id = box.BoxId }, box);
    }

    //PUT: api/boxes/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Box box)
    {
      if (id != box.BoxId)
      {
        return BadRequest();
      }

      _db.Boxes.Update(box);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!BoxExists(id))
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

    private bool BoxExists(int id)
    {
      return _db.Boxes.Any(entry => entry.BoxId == id);
    }

    //DELETE: api/boxes/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBox(int id)
    {
      Box box = await _db.Boxes.FindAsync(id);
      if (box == null)
      {
        return NotFound();
      }

      _db.Boxes.Remove(box);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}