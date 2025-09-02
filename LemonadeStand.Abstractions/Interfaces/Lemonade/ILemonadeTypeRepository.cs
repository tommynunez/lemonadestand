using System.Collections.Generic;
using System.Threading.Tasks;
using LemonadeStand.Abstractions.Entities;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface IProductTypeRepository
	{
		Task<ProductType> GetByIdAsync(int id);
		Task<IEnumerable<ProductType>> GetAllAsync(string search, int pageIndex, int pageSize, string sortField = null);
		Task InsertAsync(ProductType ProductType);
		Task UpdateAsync(int id, ProductType ProductType);
		Task DeleteAsync(int id);
		Task<IEnumerable<ProductType>> GetAllProductTypesAsync();
	}
}

