using System;
using LemonadeStand.Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface IOrderController
	{
		Task<ActionResult> InsertOrderAsync(Order order);
		Task<ActionResult> GetOrdersAsync();
	}
}

