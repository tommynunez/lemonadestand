using LemonadeStand.Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface IProductController
	{
		Task<IActionResult> GetProductsAsync();
		Task<IActionResult> GetByIdAsync(int id);
		Task InsertAsync(Product size);
		Task UpdateAsync(int id, Product size);
		Task DeleteAsync(int id);
	}
}

