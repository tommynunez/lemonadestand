using System.Collections.Generic;
using System.Threading.Tasks;
using LemonadeStand.Abstractions.Entities;

namespace LemonadeStand.Abstractions.Interfaces.Product
{
	public interface IProductTypeRepository
	{
		Task<ProductTypeEntity> GetByIdAsync(int id);
		Task<IEnumerable<ProductTypeEntity>> GetAllAsync(string search, int pageIndex, int pageSize, string sortField = null);
		Task InsertAsync(ProductTypeEntity ProductType);
		Task UpdateAsync(int id, ProductTypeEntity ProductType);
		Task DeleteAsync(int id);
		Task<IEnumerable<ProductTypeEntity>> GetAllProductTypesAsync();
	}
}

