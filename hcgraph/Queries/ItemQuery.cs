using HcGraph.Domain.Models;
using HcGraph.Domain.Services;

namespace HcGraph.Queries
{
    [ExtendObjectType("Query")]
    public class ItemQuery
    {
        public async Task<List<Item>> GetItems([Service] IOrderService orderService) => await orderService.GetItems();
        
        public async Task<Item?> GetItem([Service] IOrderService orderService, long rowId) => await orderService.GetItem(rowId);
    }
}