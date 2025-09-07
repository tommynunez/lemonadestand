namespace LemonadeStand.Abstractions.Entities
{
  public class SizeEntity : Base
  {
    public string Name { get; set; }
    public virtual List<ProductEntity> Products { get; set; }

    public SizeEntity()
    {
    }
  }
}

