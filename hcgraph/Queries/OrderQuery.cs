using HcGraph.Domain.Models;
using HcGraph.Domain.Services;

namespace HcGraph.Queries
{
    [ExtendObjectType("Query")]
    public class OrderQuery
    {
        [UsePaging]
        [UseSorting]
        [UseFiltering]
        public async Task<List<Order>> GetOrders([Service] IOrderService orderService) => await orderService.GetOrders();

        public async Task<Order?> GetOrder([Service] IOrderService orderService, long rowId) => await orderService.GetOrder(rowId);
    }
}