using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Graphql.Queries
{
    [ExtendObjectType("Query")]
    public class ProductQuery
    {
        public async Task<List<Product>> GetProductsAsync([Service] IProductService _productService)
        {
            try
            {
                var oProductslist = await _productService.GetProductsAsync();
                return oProductslist.ToList();
            }
            catch (Exception ex)
            {

            }
            return new List<Product>();
        }
    }
}

