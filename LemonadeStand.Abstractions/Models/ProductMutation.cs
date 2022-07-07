using System;
namespace LemonadeStand.Abstractions.Models
{
    public class ProductMutation
    {
		public int Id { get; set; }
		public int SizeId { get; set; }
		public int LemonadeTypeId { get; set; }
		public double Amount { get; set; }

		public ProductMutation()
        {
        }
    }
}

