using LemonadeStand.Abstractions.Interfaces.Product;
namespace LemonadeStand.Graphql.Mutations
{
  [ExtendObjectType("Mutation")]
  public class ProductMutation
  {
    public async Task<bool> InsertProductAsync(
      [Service] IProductService _productService,
      LemonadeStand.Abstractions.Models.ProductMutation product)
    {
      await _productService.InsertAsync(product);
      return true;
    }

    public async Task<bool> UpdateProductAsync(
      [Service] IProductService _productService,
      int id,
      LemonadeStand.Abstractions.Models.ProductMutation product)
    {

      await _productService.UpdateAsync(id, product);
      return true;
    }

    public async Task<bool> DeleteProductAsync(
      [Service] IProductService _productService,
      int id)
    {

      await _productService.DeleteAsync(id);
      return true;
    }
  }
}

