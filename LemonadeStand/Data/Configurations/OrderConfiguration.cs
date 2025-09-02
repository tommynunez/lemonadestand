using LemonadeStand.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LemonadeStand.Data.Configurations
{
  public class OrderConfiguration : IEntityTypeConfiguration<Order>
  {
    public void Configure(EntityTypeBuilder<Order> builder)
    {
      builder.ToTable("Order");
      builder.HasKey(o => o.Id);
      builder.Property(o => o.GuestId)
        .HasColumnName("GuestId")
        .HasColumnType("int");
      builder.Property(o => o.UserId)
        .HasColumnName("UserId")
        .HasColumnType("int");
      builder.Property(o => o.LocationId)
        .HasColumnName("LocationId")
        .HasColumnType("int");
      builder.Property(o => o.FirstName)
        .IsRequired()
        .HasColumnType("varchar(50)")
        .HasColumnName("FirstName");
      builder.Property(o => o.LastName)
        .IsRequired()
        .HasColumnType("varchar(75)")
        .HasColumnName("LastName");
      builder.Property(o => o.Phone)
        .HasColumnType("varchar(75)")
        .HasColumnName("Phone");
      builder.Property(o => o.Email)
        .HasColumnType("varchar(75)")
        .HasColumnName("Email");
      builder.Property(o => o.Created)
        .IsRequired()
        .HasColumnType("datetime")
        .HasColumnName("Created")
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .ValueGeneratedOnAdd();
      builder.Property(o => o.Udpdated)
        .HasColumnType("datetime")
        .HasColumnName("Updated")
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .ValueGeneratedOnAddOrUpdate();
      builder.Property(o => o.Deleted)
        .HasColumnType("datetime")
        .HasColumnName("Deleted")
        .HasDefaultValueSql(null);

      builder.HasOne(x => x.Location)
        .WithMany(x => x.Orders)
        .HasForeignKey(x => x.LocationId)
        .HasConstraintName("ForeignKey_Order_Location");
    }
  }
}

