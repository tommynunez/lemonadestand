using System.Collections.Generic;
using System.Threading.Tasks;
using LemonadeStand.Abstractions.Entities;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface ISizeRepository
	{
		Task<SizeEntity> GetByIdAsync( int id);
		Task<IEnumerable<SizeEntity>> GetAllAsync(string search, int pageIndex, int pageSize, string sortField = null);
		Task InsertAsync(SizeEntity size);
		Task UpdateAsync(int id, SizeEntity size);
		Task DeleteAsync(int id);
		Task<IEnumerable<SizeEntity>> GetAllSizesAsync();
	}
}

