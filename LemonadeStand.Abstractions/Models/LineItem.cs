namespace LemonadeStand.Abstractions.Models
{
  public class LineItem
  {
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public double Cost { get; set; }
    public Product? Product { get; set; }

    public LineItem()
    {
    }
  }
}

