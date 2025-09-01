namespace LemonadeStand.Abstractions.Entities
{
  public class Size : Base
  {
    public string Name { get; set; }

    public int LocationId { get; set; }

    public virtual List<Location> Locations { get; set; }

    public virtual List<Product> Products { get; set; }

    public Size()
    {
    }
  }
}

