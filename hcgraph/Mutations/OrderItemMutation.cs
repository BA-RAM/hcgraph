using HcGraph.Domain.Models;
using HcGraph.Domain.Services;

namespace HcGraph.Mutations
{
    [ExtendObjectType("Mutation")]
    public class OrderItemMutation
    {
        [UseMutationConvention]
        public async Task<OrderItem> AddOrderItemAsync([Service] IOrderService orderService, [ID] long orderID, string itemNumber, int quantity)
        {
            var orderLookup = await orderService.GetOrder(orderID);
            if (orderLookup == null)
            {
                throw new Exception("Unable to load order");
            }

            var itemLookup = await orderService.GetItemByItemNumber(itemNumber);
            if (itemLookup == null)
            {
                throw new Exception("Unable to load item");
            }

            var orderItem = new OrderItem() { OrderId = orderID, ItemId = itemLookup.RowId, Quantity = quantity };

            orderService.CreateOrderItem(orderItem);

            return orderItem;
        }
    }
}