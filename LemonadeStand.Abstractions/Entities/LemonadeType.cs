using LemonadeStand.Abstractions.Entities;

namespace LemonadeStand.Abstractions.Entities
{
	public class LemonadeType : Base
	{
		public string Name { get; set; }

		public virtual List<Product> Products { get; set; }

		public LemonadeType()
		{
		}
	}
}

