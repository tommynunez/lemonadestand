using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Abstractions.Interfaces.Product
{
  public interface IProductService
  {
    Task<LemonadeStand.Abstractions.Models.Product> GetByIdAsync(int id);
    Task InsertAsync(ProductMutation product);
    Task UpdateAsync(int id, ProductMutation product);
    Task DeleteAsync(int id);
    Task<IEnumerable<LemonadeStand.Abstractions.Models.Product>> GetAllProductsAsync();
  }
}

