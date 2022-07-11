namespace LemonadeStand.Abstractions.Models
{
	public class Product
	{
		public int? Id { get; set; }
		public Size? Size { get; set; }
		public LemonadeType? LemonadeType { get; set; }
		public double? Amount { get; set; }

		public Product()
		{

		}
	}
}

