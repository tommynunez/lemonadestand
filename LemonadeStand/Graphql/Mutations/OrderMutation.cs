using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Graphql.Mutations
{
  [ExtendObjectType("Mutation")]
  public class OrderMutation
  {
    public async Task<int> InsertOrderAsync([Service] IOrderService _orderService, Order order)
    {
      return await _orderService.InsertOrderAsync(order);
    }
  }
}

