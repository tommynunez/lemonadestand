using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Location = LemonadeStand.Abstractions.Entities.Location;

namespace LemonadeStand.Data.Configurations
{
  public class LocationConfiguration : IEntityTypeConfiguration<Location>
  {
    public void Configure(EntityTypeBuilder<Location> builder)
    {
      builder.ToTable("Location");
      builder.HasKey(lo => lo.Id);
      builder.Property(lo => lo.Name)
        .IsRequired()
        .HasColumnType("varchar(100)")
        .HasColumnName("Name");
      builder.Property(lo => lo.Description)
        .HasColumnType("varchar(400)")
        .HasColumnName ("Description");
      builder.Property(lo => lo.StreetAddressOne)
        .IsRequired()
        .HasColumnType("varchar(100)")
        .HasColumnName("StreetAddressOne");
      builder.Property(lo => lo.StreetAddressTwo)
        .HasColumnType("varchar(100)")
        .HasColumnName("StreetAddressTwo");
      builder.Property(lo => lo.City)
        .IsRequired ()
        .HasColumnType("varchar(100)")
        .HasColumnName("City");
      builder.Property(lo => lo.State)
        .IsRequired()
        .HasColumnType("varchar(2)")
        .HasColumnName("State");
      builder.Property(lo => lo.PostalCode)
        .IsRequired()
        .HasColumnType("varchar(10)")
        .HasColumnName("PostalCode");
      builder.Property(lo => lo.Country)
        .IsRequired()
        .HasColumnType("varchar(100)")
        .HasColumnName("Country");
      builder.Property(lo => lo.Phone)
        .IsRequired()
        .HasColumnType("varchar(10)")
        .HasColumnName("Phone");
      builder.Property(lo => lo.UserId)
        .IsRequired()
        .HasColumnType("int")
        .HasColumnName("Country");
    }
  }
}
