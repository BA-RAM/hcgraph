using HcGraph.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HcGraph.Domain.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly SampleDbContext _dbContext;

        public OrderItemRepository(SampleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<OrderItem>> GetOrderItems() => _dbContext.OrderItems.ToListAsync();

        public Task<OrderItem?> GetOrderItem(long rowId) => _dbContext.OrderItems.Where(oi => oi.RowId == rowId).FirstOrDefaultAsync();

        public Task<List<OrderItem>> GetOrderItemsByOrderId(long orderId) => _dbContext.OrderItems.Where(oi => oi.OrderId == orderId).ToListAsync();

        public void Create(OrderItem orderItem)
        {
            _dbContext.OrderItems.Add(orderItem);
            _dbContext.SaveChanges();
        }
    }
}