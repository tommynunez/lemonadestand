
using LemonadeStand.Abstractions.Entities;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface ILineItemRepository
	{
		Task InsertLineItemAsync(IEnumerable<LineItem> lineItems);
	}
}

