using LemonadeStand.Abstractions.Interfaces.Product;
using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Graphql.Mutations
{
  [ExtendObjectType("Mutation")]
  public class ProductTypeMutation
  {
    public async Task<bool> InsertProductTypeAsync([Service] IProductTypeService _ProductTypeService, ProductType ProductType)
    {
      await _ProductTypeService.InsertAsync(ProductType);
      return true;
    }

    public async Task<bool> UpdateProductTypeAsync([Service] IProductTypeService _ProductTypeService, int id, ProductType ProductType)
    {

      await _ProductTypeService.UpdateAsync(id, ProductType);
      return true;
    }

    public async Task<bool> DeleteProductTypeAsync([Service] IProductTypeService _ProductTypeService, int id)
    {

      await _ProductTypeService.DeleteAsync(id);
      return true;
    }
  }
}

