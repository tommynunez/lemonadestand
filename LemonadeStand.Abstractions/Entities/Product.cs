namespace LemonadeStand.Abstractions.Entities
{
  public class Product : Base
  {
    public int LemonadeTypeId { get; set; }
    public int SizeId { get; set; }
    public double Amount { get; set; }
    public int LocationId { get; set; }

    public virtual List<Location> Locations { get; set; }
    public virtual LemonadeType LemonadeType { get; set; }
    public virtual List<LineItem>? LineItems { get; set; }
    public virtual Size Size { get; set; }

    public Product()
    {
    }
  }
}

