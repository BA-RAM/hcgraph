using System;
using hcgraph.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace hcgraph.Domain.Repositories
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetOrders();
        public Task<Order?> GetOrder(long rowId);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly SampleDbContext _dbContext;

        public OrderRepository(SampleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Order>> GetOrders() => _dbContext.Orders.ToListAsync();
        public Task<Order?> GetOrder(long rowId) => _dbContext.Orders.Where(o => o.RowId == rowId).FirstOrDefaultAsync();
    }
}

