using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RentACar.Domain.Entities;

namespace RentACar.Persistence.Contexts;
public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<Brand> Brands { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //if (!optionsBuilder.IsConfigured)
        //    base.OnConfiguring(
        //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(_brand =>
        {
            _brand.HasKey(entity => entity.Id);
            _brand.Property(entity => entity.Id);
            _brand.Property(entity => entity.Name);
        });

        Brand[] someFeatureEntitySeeds = { new Brand(1, "Tofaş") };
        modelBuilder.Entity<Brand>().HasData(someFeatureEntitySeeds);
    }
}
