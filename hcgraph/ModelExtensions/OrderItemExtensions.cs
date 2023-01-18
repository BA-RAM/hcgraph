using hcgraph.Domain.Models;
using hcgraph.Domain.Services;

namespace hcgraph.ModelExtensions
{
    [ExtendObjectType(typeof(OrderItem))]
    public class OrderItemExtensions
    {
        public async Task<Item?> GetItem(
            [Service] IOrderService orderService,
            [Parent] OrderItem orderItem
        ) => await orderService.GetItem(orderItem.ItemId);

        public async Task<decimal> GetTotal(
            [Service] IOrderService orderService,
            [Parent] OrderItem orderItem
        )
        {
            var item = await orderService.GetItem(orderItem.ItemId);

            if (item == null || !item.Price.HasValue)
                return 0;

            return orderItem.Quantity * item.Price.Value;
        }

        public async Task<string> GetDisplayName(
            [Service] IOrderService orderService,
            [Parent] OrderItem orderItem
        )
        {
            var item = await orderService.GetItem(orderItem.ItemId);

            return $"{item?.Name} ({item?.ItemNumber}) - Qty: {orderItem.Quantity}";
        }
    }
}
