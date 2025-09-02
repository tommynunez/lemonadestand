using System;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Graphql.Mutations
{
  [ExtendObjectType("Mutation")]
  public class ProductTypeMutation
  {
    public async Task<bool> InsertProductTypeAsync([Service] IProductTypeService _ProductTypeService, ProductType ProductType)
    {
      try
      {
        await _ProductTypeService.InsertAsync(ProductType);
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<bool> UpdateProductTypeAsync([Service] IProductTypeService _ProductTypeService, int id, ProductType ProductType)
    {
      try
      {
        await _ProductTypeService.UpdateAsync(id, ProductType);
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<bool> DeleteProductTypeAsync([Service] IProductTypeService _ProductTypeService, int id)
    {
      try
      {
        await _ProductTypeService.DeleteAsync(id);
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

  }
}

