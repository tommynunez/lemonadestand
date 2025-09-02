using System.Threading.Tasks;
using LemonadeStand.Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface IProductTypeController
	{
		Task<ActionResult> GetByIdAsync([FromRoute] int id);
		Task<ActionResult> GetAllAsync([FromQuery] string search, [FromQuery] int pageIndex, [FromQuery] int pageSize, [FromQuery] string sortField = null);
		Task<ActionResult> InsertAsync([FromBody] ProductType ProductType);
		Task<ActionResult> UpdateAsync([FromRoute] int id, [FromBody] ProductType ProductType);
		Task<ActionResult> DeleteAsync([FromRoute] int id);
	}
}

