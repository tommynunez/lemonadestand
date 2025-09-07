
using LemonadeStand.Abstractions.Entities;
using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LemonadeStand.Data
{
  public class DatabaseContext : DbContext, IMigratable
  {
    public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
    {
    });

    public IConfiguration Configuration { get; }
    public DbSet<ProductTypeEntity> ProductTypes { get; set; }
    public DbSet<LineItemEntity> LineItems { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<SizeEntity> Sizes { get; set; }
    public DbSet<Abstractions.Entities.LocationEntity> Locations { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder
            .UseLoggerFactory(MyLoggerFactory)
            .UseSqlServer(Configuration.GetConnectionString("LemonadeStandDatabase"));
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfiguration(new LineItemConfiguration());
      modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
      modelBuilder.ApplyConfiguration(new SizeConfiguration());
      modelBuilder.ApplyConfiguration(new ProductConfiguration());
      modelBuilder.ApplyConfiguration(new OrderConfiguration());
      modelBuilder.ApplyConfiguration(new LocationConfiguration());
    }
  }
}

