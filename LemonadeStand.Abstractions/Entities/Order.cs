namespace LemonadeStand.Abstractions.Entities
{
  public class Order : Base
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public double TotalCost { get; set; }
    public string GuestId { get; set; }
    public int UserId { get; set; }
    public int LocationId { get; set; }

    public virtual List<LineItem> LineItems { get; set; }
    public virtual List<Location> Locations { get; set; }

    public Order()
    {
    }
  }
}

