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

    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<Freezer>>> Get([FromQuery] int? freezerNum)
    // {
    //   IQueryable<Freezer> query = _db.Freezers.AsQueryable();

    //   if (freezerNum.HasValue)
    //   {
    //     query = query.Where(entry => entry.FreezerNum == freezerNum.Value);
    //   }

    //   return await query.ToListAsync();
    // } returns specific freezerNum or all if not matching
  }
}