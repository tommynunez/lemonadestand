using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Graphql.Mutations
{
    [ExtendObjectType("Mutation")]
    public class OrderMutation
    {
        public async Task<bool> InsertOrderAsync([Service] IOrderService _orderService, Order order)
        {
            try
            {
                await _orderService.InsertOrderAsync(order);
                return true;
            } catch(Exception ex)
            {
                return false;
            }
        }
    }
}

