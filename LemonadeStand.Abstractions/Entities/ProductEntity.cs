namespace LemonadeStand.Abstractions.Entities
{
  public class ProductEntity : Base
  {
    public int ProductTypeId { get; set; }
    public int SizeId { get; set; }
    public double Amount { get; set; }
    public int LocationId { get; set; }

    public virtual LocationEntity Location { get; set; }
    public virtual ProductTypeEntity ProductType { get; set; }
    public virtual List<LineItemEntity>? LineItems { get; set; }
    public virtual SizeEntity Size { get; set; }

    public ProductEntity()
    {
    }
  }
}

