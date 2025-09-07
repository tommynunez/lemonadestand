using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Graphql.Mutations
{
  [ExtendObjectType("Mutation")]
  public class SizeMutation
  {
    public async Task<bool> InsertSizeAsync([Service] ISizeService _sizeService, Size size)
    {
      await _sizeService.InsertAsync(size);
      return true;
    }

    public async Task<bool> UpdateSizeAsync([Service] ISizeService _sizeService, int id, Size size)
    {
      await _sizeService.UpdateAsync(id, size);
      return true;
    }

    public async Task<bool> DeleteSizeAsync([Service] ISizeService _sizeService, int id)
    {
      await _sizeService.DeleteAsync(id);
      return true;
    }
  }
}

