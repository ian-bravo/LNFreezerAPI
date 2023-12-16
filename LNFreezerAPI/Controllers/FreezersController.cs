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
    public async Task<ActionResult<IEnumerable<Freezer>>> Get(int freezerNum)
    {
      IQueryable<Freezer> query = _db.Freezers.AsQueryable();

      if (freezerNum != 0)
      {
        query = query.Where(entry => entry.FreezerNum = freezerNum);
      }

      return await query.ToListAsync();
    }
  }
}