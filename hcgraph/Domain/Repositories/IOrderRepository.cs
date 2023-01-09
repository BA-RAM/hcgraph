using HcGraph.Domain.Models;

namespace HcGraph.Domain.Repositories
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetOrders();

        public Task<Order?> GetOrder(long rowId);
    }
}