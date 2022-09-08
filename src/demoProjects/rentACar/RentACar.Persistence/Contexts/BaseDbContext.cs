using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RentACar.Domain.Entities;

namespace RentACar.Persistence.Contexts;
public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Model> Models { get; set; }

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
            _brand.Property(entity => entity.Id).HasColumnName("Id");
            _brand.Property(entity => entity.Name).HasColumnName("Name");
            _brand.HasMany(entity => entity.Models);
        });

        Brand[] brandSeeds = { new Brand(1, "Tofaş") };
        modelBuilder.Entity<Brand>().HasData(brandSeeds);

        modelBuilder.Entity<Model>(_model =>
        {
            _model.HasKey(entity => entity.Id);
            _model.Property(entity => entity.Id).HasColumnName("Id");
            _model.Property(entity => entity.Name).HasColumnName("Name");
            _model.Property(entity => entity.BrandId).HasColumnName("BrandId");
            _model.Property(entity => entity.DailyPrice).HasColumnName("DailyPrice");
            _model.Property(entity => entity.ImageUrl).HasColumnName("ImageUrl");
            _model.HasOne(entity => entity.Brand);
        });

        Model[] modelDataSeeds = { 
            new Model(1, 1, "Doğan SLX", 200, "https://i0.shbdn.com/photos/75/61/49/x5_1033756149w09.jpg")
        };
        modelBuilder.Entity<Model>().HasData(modelDataSeeds);
    }
}
