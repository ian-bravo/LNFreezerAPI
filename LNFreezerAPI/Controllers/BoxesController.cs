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
    public async Task<ActionResult<IEnumerable<Box>>> Get(string boxAlpha, [FromQuery] int? rackId)
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

      return await query.ToListAsync();
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
  }
}