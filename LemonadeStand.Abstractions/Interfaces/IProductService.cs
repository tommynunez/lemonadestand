using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface IProductService
	{
		Task<Product> GetByIdAsync(int id);
		Task InsertAsync(Product product);
		Task UpdateAsync(int id, Product product);
		Task DeleteAsync(int id);
		Task<IEnumerable<Product>> GetAllProductsAsync();
	}
}

