namespace LemonadeStand.Abstractions.Models
{
	public class Order
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public double TotalCost { get; set; }
		public List<LineItem> LineItems { get; set; } = new List<LineItem>();

		public Order()
		{
		}
	}
}

