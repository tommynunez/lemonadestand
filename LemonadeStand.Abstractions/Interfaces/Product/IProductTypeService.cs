using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Abstractions.Interfaces.Product
{
  public interface IProductTypeService
  {
    Task<ProductType> GetByIdAsync(int id);
    Task<IEnumerable<ProductType>> GetAllAsync(string search, int pageIndex, int pageSize, string sortField = null);
    Task InsertAsync(ProductType ProductType);
    Task UpdateAsync(int id, ProductType ProductType);
    Task DeleteAsync(int id);
    Task<IEnumerable<ProductType>> GetAllProductTypesAsync();
  }
}

