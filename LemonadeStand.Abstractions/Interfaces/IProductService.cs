using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface IProductService
	{
		Task<IEnumerable<Product>> GetProductsAsync();
	}
}

