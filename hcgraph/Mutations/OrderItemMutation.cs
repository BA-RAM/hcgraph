using hcgraph.Domain.Models;
using hcgraph.Domain.Services;

namespace hcgraph.Mutations
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

            var orderItem = new OrderItem() {OrderId = orderID, ItemId = itemLookup.RowId, Quantity = quantity};

            orderService.CreateOrderItem(orderItem);

            return orderItem;
        }

        [UseMutationConvention]
        public async Task<Order> DeleteOrderItemAsync([Service] IOrderService orderService, [ID] long orderItemID) 
        {
            var orderItemLookup = await orderService.GetOrderItem(orderItemID);
            if (orderItemLookup == null)
            {
                throw new Exception("Unable to load order item");
            }

            orderService.DeleteOrderItem(orderItemLookup);
            
            var orderLookup = await orderService.GetOrder(orderItemLookup.OrderId);
            if (orderLookup == null)
            {
                throw new Exception("Unable to load order");
            }

            return orderLookup;
        }
    }
}