using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Graphql.Queries
{
    [ExtendObjectType("Query")]
    public class LemonadeTypeQuery
    {
        public async Task<LemonadeType> RetrieveLemonadeTypeById([Service] ILemonadeTypeService _lemonadeTypeService, int id)
        {
            var oLemoandeType = new LemonadeType();
            try
            {
                oLemoandeType = await _lemonadeTypeService.GetByIdAsync(id);
                return oLemoandeType;
            }
            catch (Exception ex)
            {
                
            }
            return oLemoandeType;
        }

        public async Task<IEnumerable<LemonadeType>> RetrieveAllLemonadeTypes([Service] ILemonadeTypeService _lemonadeTypeService, string search,
            int pageIndex, int pageSize, string sortField = null)
        {
            try
            {
                var oLemoandeTypelist = await _lemonadeTypeService.GetAllAsync(search, pageIndex, pageSize, sortField);
                oLemoandeTypelist.ToList();
                return oLemoandeTypelist;
            }
            catch (Exception ex)
            {

            }
            return new List<LemonadeType>();
        }
    }
}

