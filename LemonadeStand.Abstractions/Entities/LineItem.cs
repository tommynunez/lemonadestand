namespace LemonadeStand.Abstractions.Entities
{
	public class LineItem : Base
	{
		public int ProductId { get; set; }
		public int OrderId { get; set; }
		public int Quantity { get; set; }
		public double Cost { get; set; }

		public virtual Product? Product { get; set; }
		public virtual Order? Order { get; set; }

		public LineItem()
		{
		}
	}
}

