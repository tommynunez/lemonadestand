namespace LemonadeStand.Abstractions.Entities
{
  public class LineItemEntity : Base
  {
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }
    public double Cost { get; set; }

    public virtual ProductEntity? Product { get; set; }
    public virtual OrderEntity? Order { get; set; }
    public virtual LocationEntity? Location { get; set; }

    public LineItemEntity()
    {
    }
  }
}

