using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface IOrderService
	{
		Task<bool> InsertOrderAsync(Order order);
		Task<IEnumerable<Order>> GetOrdersAsync();
	}
}

