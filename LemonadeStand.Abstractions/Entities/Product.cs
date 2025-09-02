namespace LemonadeStand.Abstractions.Entities
{
  public class Product : Base
  {
    public int ProductTypeId { get; set; }
    public int SizeId { get; set; }
    public double Amount { get; set; }
    public int LocationId { get; set; }

    public virtual Location Location { get; set; }
    public virtual ProductType ProductType { get; set; }
    public virtual List<LineItem>? LineItems { get; set; }
    public virtual Size Size { get; set; }

    public Product()
    {
    }
  }
}

