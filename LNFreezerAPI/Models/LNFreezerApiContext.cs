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

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Freezer>()
      .HasData(
        new Freezer { FreezerId = 1, FreezerNum = 1 },
        new Freezer { FreezerId = 2, FreezerNum = 2 },
        new Freezer { FreezerId = 3, FreezerNum = 3 }
      );
      builder.Entity<Rack>()
      .HasData(
        new Rack { RackId = 1, RackNum = 1, FreezerId = 1 },
        new Rack { RackId = 6, RackNum = 6, FreezerId = 1 },
        new Rack { RackId = 50, RackNum = 30, FreezerId = 5 },
        new Rack { RackId = 10, RackNum = 30, FreezerId = 7 }
      );
      builder.Entity<Box>()
      .HasData(
        new Box { BoxId = 1, BoxAlpha = "A", RackId = 1 }
      );
    }
  }
}