using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;
using Microsoft.Toolkit.Diagnostics;

namespace LemonadeStand.Graphql.Queries
{
    [ExtendObjectType("Query")]
    public class ProductTypeQuery
    {
        public async Task<ProductType?> RetrieveProductTypeById([Service] IProductTypeService _ProductTypeService, int id)
        {
            var oLemoandeType = new ProductType();
            try
            {
                oLemoandeType = await _ProductTypeService.GetByIdAsync(id);
                return oLemoandeType;
            }
            catch (Exception ex)
            {
                
            }
            return oLemoandeType;
        }

        public async Task<IEnumerable<ProductType>> RetrieveAllProductTypes([Service] IProductTypeService _ProductTypeService)
        {
            try
            {
                var oLemoandeTypelist = await _ProductTypeService.GetAllProductTypesAsync();
                oLemoandeTypelist.ToList();
                return oLemoandeTypelist;
            }
            catch (Exception ex)
            {

            }
            return new List<ProductType>();
        }
    }
}

