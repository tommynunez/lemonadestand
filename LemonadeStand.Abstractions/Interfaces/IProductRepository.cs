using LemonadeStand.Abstractions.Entities;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface IProductRepository
	{
		Task<IEnumerable<Product>> GetProductsAsync();
	}
}

