using Microsoft.EntityFrameworkCore;

namespace LNFreezerApi.Models
{
  public class LNFreezerApiContext : DbContext
  {
    public DbSet<Freezer> Freezers { get; set; }
    public DbSet<Rack> Racks { get; set; }
    public DbSet<Box> Boxes { get; set; }
    public DbSet<Specimen> Specimens { get; set; }

    public LNFreezerApiContext(DbContextOptions<LNFreezerApiContext> options) : base(options)
    {
    }
  }
}