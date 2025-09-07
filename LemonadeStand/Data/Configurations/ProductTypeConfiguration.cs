using LemonadeStand.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LemonadeStand.Data.Configurations
{
  public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductTypeEntity>
  {
    public ProductTypeConfiguration()
    {
    }

    public void Configure(EntityTypeBuilder<ProductTypeEntity> builder)
    {
      builder.ToTable("ProductType");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Name)
        .IsRequired()
        .HasColumnType("varchar(50)")
        .HasColumnName("Name");
      builder.Property(l => l.Created)
        .IsRequired()
        .HasColumnType("datetime")
        .HasColumnName("Created")
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .ValueGeneratedOnAdd();
      builder.Property(l => l.Udpdated)
        .HasColumnType("datetime")
        .HasColumnName("Updated")
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .ValueGeneratedOnAddOrUpdate();
      builder.Property(l => l.Deleted)
        .HasColumnType("datetime")
        .HasColumnName("Deleted");

      //builder.HasData(new ProductType
      //{
      //	Id = 1,
      //	Name = "Regular Lemonade",
      //	Created = DateTime.Now,
      //	Udpdated = DateTime.Now
      //}, new ProductType
      //{
      //	Id = 2,
      //	Name = "Pink Lemonade",
      //	Created = DateTime.Now,
      //	Udpdated = DateTime.Now
      //});
    }
  }
}

