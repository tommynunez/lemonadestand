using LemonadeStand.Abstractions.Interfaces.Product;
using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Graphql.Queries
{
  [ExtendObjectType("Query")]
  public class ProductTypeQuery
  {
    public async Task<ProductType?> RetrieveProductTypeById([Service] IProductTypeService _ProductTypeService, int id)
    {
      var oLemoandeType = new ProductType();
      oLemoandeType = await _ProductTypeService.GetByIdAsync(id);
      return oLemoandeType;
    }

    public async Task<IEnumerable<ProductType>> RetrieveAllProductTypes([Service] IProductTypeService _ProductTypeService)
    {
      var oLemoandeTypelist = await _ProductTypeService.GetAllProductTypesAsync();
      oLemoandeTypelist.ToList();
      return oLemoandeTypelist;
    }
  }
}

