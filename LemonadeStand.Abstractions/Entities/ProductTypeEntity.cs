namespace LemonadeStand.Abstractions.Entities
{
  public class ProductTypeEntity : Base
  {
    public string Name { get; set; }

    public virtual List<ProductEntity> Products { get; set; }

    public ProductTypeEntity()
    {
    }
  }
}

