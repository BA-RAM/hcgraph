using HcGraph.Domain.Models;

namespace HcGraph.Domain.Services
{
    public interface IOrderService
    {
        public Task<List<Order>> GetOrders();

        public Task<Order?> GetOrder(long id);

        public Task<List<OrderItem>> GetOrderItems();

        public Task<OrderItem?> GetOrderItem(long id);

        public Task<List<OrderItem>> GetOrderItemsByOrderId(long orderId);

        public void CreateOrderItem(OrderItem orderItem);

        public Task<List<Item>> GetItems();

        public Task<Item?> GetItem(long id);

        public Task<Item?> GetItemByItemNumber(string itemNumber);
    }
}