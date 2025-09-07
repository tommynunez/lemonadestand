using LemonadeStand.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LemonadeStand.Data.Configurations
{
  public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
  {
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
      builder.ToTable("Product");
      builder.HasKey(li => li.Id);
      builder.Property(l => l.ProductTypeId)
        .IsRequired()
        .HasColumnType("int")
        .HasColumnName("ProductTypeId");
      builder.Property(l => l.LocationId)
        .IsRequired()
        .HasColumnType("int")
        .HasColumnName("LocationId");
      builder.Property(l => l.SizeId)
        .IsRequired()
        .HasColumnType("int")
        .HasColumnName("SizeId");
      builder.Property(l => l.Amount)
        .IsRequired()
        .HasColumnType("float")
        .HasColumnName("Amount");
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
        .ValueGeneratedOnAddOrUpdate(); ;
      builder.Property(l => l.Deleted)
        .HasColumnType("datetime")
        .HasColumnName("Deleted");

      builder.HasMany(x => x.LineItems)
        .WithOne(x => x.Product);

      builder.HasOne(x => x.ProductType)
        .WithMany(x => x.Products)
        .HasForeignKey(x => x.ProductTypeId)
        .HasConstraintName("ForeignKey_Product_ProductType");

      builder.HasOne(x => x.Size)
        .WithMany(x => x.Products)
        .HasForeignKey(x => x.SizeId)
        .HasConstraintName("ForeignKey_Product_Size");

      builder.HasOne(x => x.Location)
        .WithMany(x => x.Products)
        .HasForeignKey(x => x.LocationId)
        .HasConstraintName("ForeignKey_Product_Location");

      //  builder.HasData(new Product
      //  {
      //    Id = 1,
      //    ProductTypeId = 1,

      //    SizeId = 1,
      //    Amount = 0.75,
      //    Created = DateTime.Now,
      //    Udpdated = DateTime.Now
      //  },
      //  new Product
      //  {
      //    Id = 2,
      //    ProductTypeId = 1,
      //    SizeId = 2,
      //    Amount = 1.50,
      //    Created = DateTime.Now,
      //    Udpdated = DateTime.Now
      //  }, new Product
      //  {
      //    Id = 3,
      //    ProductTypeId = 2,
      //    SizeId = 1,
      //    Amount = 0.75,
      //    Created = DateTime.Now,
      //    Udpdated = DateTime.Now
      //  }, new Product
      //  {
      //    Id = 4,
      //    ProductTypeId = 2,
      //    SizeId = 2,
      //    Amount = 1.50,
      //    Created = DateTime.Now,
      //    Udpdated = DateTime.Now
      //  });
      //}
    }
  }
}