using LemonadeStand.Abstractions.Entities;
using LemonadeStand.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LemonadeStand.Data.Repositories
{
  public class OrderRepository : IOrderRepository
  {
    private readonly DatabaseContext _context;
    private readonly ILogger<OrderRepository> _logger;
    private readonly int _userId;

    private const string ORDER_INSERT_MESSAGE = "";
    private const string ORDER_INSERT_ERROR_MESSAGE = "Error Message: {0}";

    public OrderRepository(DatabaseContext context,
        ILogger<OrderRepository> logger,
        HttpContext httpContext)
    {
      _context = context;
      _logger = logger;
      _userId = (int)httpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier).First();
    }

    public async Task<int> InsertOrderAsync(OrderEntity order)
    {
      var returnValue = 0;
      try
      {
        _logger.LogInformation(ORDER_INSERT_MESSAGE);
        order.UserId = _userId;
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        returnValue = order.Id;
      }
      catch (Exception ex)
      {
        _logger.LogInformation(ORDER_INSERT_ERROR_MESSAGE, ex.Message);
      }
      return returnValue;
    }

    public async Task<IEnumerable<OrderEntity>> GetOrdersAsync()
    {
      var eOrderList = new List<OrderEntity>();

      try
      {
        //_logger.LogInformation(GET_PRODUCT_MESSAGE);
        eOrderList = await _context.Orders
            .Include(x => x.LineItems)
                .ThenInclude(x => x.Product)
                    .ThenInclude(x => x.ProductType)
                .ThenInclude(x => x.Products)
                    .ThenInclude(x => x.Size)
                    .OrderByDescending(x => x.Created)
            .ToListAsync();
      }
      catch (Exception ex)
      {
        //_logger.LogError(GET_PRODUCT_ERROR_MESSAGE, ex.Message);
      }

      return eOrderList;
    }
  }
}