using System;
using hcgraph.Domain.Models;
using hcgraph.Domain.Services;

namespace hcgraph.ModelExtensions
{
    [ExtendObjectType(typeof(Order))]
    public class OrderExtensions
    {
        public async Task<List<OrderItem>> GetOrderItems([Service] IOrderService orderService, [Parent] Order order) => await orderService.GetOrderItemsByOrderId(order.RowId);
    }
}

