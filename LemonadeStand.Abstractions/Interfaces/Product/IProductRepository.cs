namespace LemonadeStand.Abstractions.Interfaces
{
  public interface IProductRepository
  {
    Task<LemonadeStand.Abstractions.Entities.ProductEntity> GetByIdAsync(int id);
    Task InsertAsync(LemonadeStand.Abstractions.Entities.ProductEntity product);
    Task UpdateAsync(int id, LemonadeStand.Abstractions.Entities.ProductEntity product);
    Task DeleteAsync(int id);
    Task<IEnumerable<LemonadeStand.Abstractions.Entities.ProductEntity>> GetAllProductsAsync();
  }
}

