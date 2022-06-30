using LemonadeStand.Abstractions.Entities;
using LemonadeStand.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LemonadeStand.Data.Repositories
{
	public class ProductRepository : IProductRepository
	{
        private readonly DatabaseContext _databaseContext;
        private readonly ILogger<ProductRepository> _logger;

        private const string GET_PRODUCT_MESSAGE = "Getting Products";
        private const string GET_PRODUCT_ERROR_MESSAGE = "Error Message {0}";

		public ProductRepository(DatabaseContext databaseContext,
            ILogger<ProductRepository> logger)
		{
            _databaseContext = databaseContext;
            _logger = logger;
		}

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var eProductList = new List<Product>();

            try
            {
                _logger.LogInformation(GET_PRODUCT_MESSAGE);
                eProductList = await _databaseContext.Products
                    .Include(x => x.Sizes)
                    .Include(x => x.LemonadeTypes).ToListAsync();
            } catch(Exception ex)
            {
                _logger.LogError(GET_PRODUCT_ERROR_MESSAGE, ex.Message);
            }

            return eProductList;
        }
    }
}

