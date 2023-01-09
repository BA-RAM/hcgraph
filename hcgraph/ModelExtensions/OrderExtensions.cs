using HcGraph.Domain.Models;
using HcGraph.Domain.Services;

namespace HcGraph.ModelExtensions
{
    [ExtendObjectType(typeof(Order))]
    public class OrderExtensions
    {
        public async Task<List<OrderItem>> GetOrderItems([Service] IOrderService orderService, [Parent] Order order) => await orderService.GetOrderItemsByOrderId(order.RowId);
    }
}