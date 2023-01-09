using hcgraph.Domain.Models;
using hcgraph.Domain.Services;

namespace hcgraph.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class OrderItemResolver
    {
        public async Task<List<OrderItem>> GetOrderItems([Service] IOrderService orderService) => await orderService.GetOrderItems();
        public async Task<OrderItem?> GetOrderItem([Service] IOrderService orderService, long rowId) => await orderService.GetOrderItem(rowId);
    }
}

