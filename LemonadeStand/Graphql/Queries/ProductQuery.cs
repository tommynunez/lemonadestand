using LemonadeStand.Abstractions.Interfaces.Product;
using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Graphql.Queries
{
  [ExtendObjectType("Query")]
  public class ProductQuery
  {
    public async Task<List<Product>> GetProductsAsync([Service] IProductService _productService)
    {
      var oProductslist = await _productService.GetAllProductsAsync();
      return oProductslist.ToList();
    }

    public async Task<Product?> RetrieveProductById([Service] IProductService _productService, int id)
    {
      var oProduct = new Product();

      oProduct = await _productService.GetByIdAsync(id);
      return oProduct;
    }
  }
}

