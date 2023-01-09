using HcGraph.Domain.Models;

namespace HcGraph.Domain.Repositories
{
    public interface IOrderItemRepository
    {
        public void Create(OrderItem orderItem);

        public Task<List<OrderItem>> GetOrderItems();

        public Task<OrderItem?> GetOrderItem(long rowId);

        public Task<List<OrderItem>> GetOrderItemsByOrderId(long orderId);
    }
}