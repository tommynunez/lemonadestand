using Microsoft.AspNetCore.Mvc;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface IProductController
	{
		Task<ActionResult> GetProductsAsync();
	}
}

