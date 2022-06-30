namespace LemonadeStand.Abstractions.Models
{
	public class LineItem
	{
		public int Quantity { get; set; }
		public int ProductId { get; set; }
		public double Cost { get; set; }

		public LineItem()
		{
		}
	}
}

