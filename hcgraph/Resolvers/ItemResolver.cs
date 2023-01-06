using System;
using hcgraph.Domain.Models;
using hcgraph.Domain.Services;

namespace hcgraph.Resolvers
{
    [ExtendObjectType("Query")]
    public class ItemResolver
    {
        public async Task<List<Item>> GetItems([Service] IOrderService orderService) => await orderService.GetItems();
        public async Task<Item?> GetItem([Service] IOrderService orderService, long rowId) => await orderService.GetItem(rowId);
    }
}

