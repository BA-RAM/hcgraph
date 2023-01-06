using System;
using hcgraph.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace hcgraph.Domain.Repositories
{
    public interface IItemRepository
    {
        public Task<List<Item>> GetItems();
        public Task<Item?> GetItem(long rowID);
    }

    public class ItemRepository : IItemRepository
    {
        private readonly SampleDbContext _dbContext;

        public ItemRepository(SampleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Item>> GetItems() => _dbContext.Items.ToListAsync();
        public Task<Item?> GetItem(long rowID) => _dbContext.Items.Where(i => i.RowId == rowID).FirstOrDefaultAsync();
    }
}

