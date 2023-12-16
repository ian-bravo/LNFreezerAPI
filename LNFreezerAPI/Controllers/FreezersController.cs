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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Freezer>>> Get([FromQuery] int? freezerNum)
    {
      IQueryable<Freezer> query = _db.Freezers.AsQueryable();

      if (freezerNum.HasValue)
      {
        query = query.Where(entry => entry.FreezerNum == freezerNum.Value);
      }

      return await query.ToListAsync();
    }
  }
}