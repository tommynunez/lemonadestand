namespace LemonadeStand.Abstractions.Entities
{
  public class OrderEntity : Base
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public double TotalCost { get; set; }
    public string GuestId { get; set; }
    public int UserId { get; set; }
    public int LocationId { get; set; }

    public virtual List<LineItemEntity> LineItems { get; set; }
    public virtual LocationEntity Location { get; set; }

    public virtual ProductTypeEntity ProductType { get; set; }

    public OrderEntity()
    {
    }
  }
}

