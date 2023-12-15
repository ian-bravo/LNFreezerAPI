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
          new Box { BoxId = 1, BoxAlpha = "A", RackId = 1 },
          new Box { BoxId = 20, BoxAlpha = "A", RackId = 45 },
          new Box { BoxId = 25, BoxAlpha = "C", RackId = 3 },
          new Box { BoxId = 30, BoxAlpha = "D", RackId = 50 }
        );
      builder.Entity<Specimen>()
        .HasData(
          new Specimen { SpecimenId = 1, SpecimenNum = 1, Cohort = "PC475", NHPNum = 32283, Date = 051422, Tissue = "BM", Quantity = "2e6", BoxId = 1 },
          new Specimen { SpecimenId = 4, SpecimenNum = 4, Cohort = "PC475", NHPNum = 33887, Date = 052122, Tissue = "PBMC", Quantity = "8e6", BoxId = 4 },
          new Specimen { SpecimenId = 10, SpecimenNum = 10, Cohort = "PC498", NHPNum = 29396, Date = 091722, Tissue = "PBMC", Quantity = "15e6", BoxId = 20 },
          new Specimen { SpecimenId = 82, SpecimenNum = 1, Cohort = "PC521", NHPNum = 34331, Date = 062123, Tissue = "P.LN", Quantity = "8e6", BoxId = 39 }
        );
    }
  }
}