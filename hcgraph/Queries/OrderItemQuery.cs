using HcGraph.Domain.Models;
using HcGraph.Domain.Services;

namespace HcGraph.Queries
{
    [ExtendObjectType("Query")]
    public class OrderItemQuery
    {
        public async Task<List<OrderItem>> GetOrderItems([Service] IOrderService orderService) => await orderService.GetOrderItems();
        
        public async Task<OrderItem?> GetOrderItem([Service] IOrderService orderService, long rowId) => await orderService.GetOrderItem(rowId);
    }
}