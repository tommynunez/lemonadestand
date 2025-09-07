namespace LemonadeStand.Abstractions.Entities
{
  public class LocationEntity : Base
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string StreetAddressOne { get; set; }
    public string StreetAddressTwo { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    public string UserId { get; set; }

    public virtual List<ProductEntity> Products { get; set; }

    public virtual List<SizeEntity> Sizes { get; set; }

    public virtual List<OrderEntity> Orders { get; set; }

    public LocationEntity() { }
  }
}
